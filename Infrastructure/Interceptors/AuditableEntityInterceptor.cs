﻿using Domain.Contracts;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Interceptors;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    private readonly IUserInfo _user;
    private readonly TimeProvider _dateTime;

    public AuditableEntityInterceptor(
        IUserInfo user,
        TimeProvider dateTime)
    {
        _user = user;
        _dateTime = dateTime;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public void UpdateEntities(DbContext? context)
    {
        if (context == null)
            return;

        var utcNow = _dateTime.GetUtcNow();

        foreach (var entry in context.ChangeTracker.Entries<AuditableEntityBase>())
        {
            if (entry.State is EntityState.Added or EntityState.Modified || entry.HasChangedOwnedEntities())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = _user.User.Id;
                    entry.Entity.Created = utcNow;
                }

                if (entry.State == EntityState.Deleted)
                {
                    entry.Entity.DeletedBy = _user.User.Id;
                    entry.Entity.DeletedDate = utcNow;
                }

                entry.Entity.LastModifiedBy = _user.User.Id;
                entry.Entity.LastModified = utcNow;
            }
        }
    }
}

public static class Extensions
{
    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(r =>
            r.TargetEntry != null &&
            r.TargetEntry.Metadata.IsOwned() &&
            (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
}
