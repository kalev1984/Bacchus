using System;

namespace Contracts.DAL.Base
{
    
    public interface IBaseEntity : IBaseEntity<Guid>
    {
        
    }

    public interface IBaseEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}