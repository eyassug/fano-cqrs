﻿namespace Fano.CQRS.EventSourcing
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents an identifiable entity that is event sourced.
    /// </summary>
    public interface IEventSourced<TKey>
    {
        
        /// <summary>
        /// Gets the entity identifier.
        /// </summary>
        TKey Id { get; }

        /// <summary>
        /// Gets the entity's version. As the entity is being updated and events being generated, the version is incremented.
        /// </summary>
        int Version { get; }

        /// <summary>
        /// Gets the collection of new events since the entity was loaded, as a consequence of command handling.
        /// </summary>
        IEnumerable<IVersionedEvent> Events { get; }
    }
}
