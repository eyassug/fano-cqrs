namespace Fano.CQRS.EventSourcing
{
    using System;

    public class EntityNotFoundException : Exception
    {
        private readonly object entityId;
        private readonly string entityType;

        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(object entityId) : base(entityId.ToString())
        {
            this.entityId = entityId;
        }

        public EntityNotFoundException(object entityId, string entityType)
            : base(entityType + ": " + entityId.ToString())
        {
            this.entityId = entityId;
            this.entityType = entityType;
        }

        public EntityNotFoundException(object entityId, string entityType, string message, Exception inner) 
            : base(message, inner)
        {
            this.entityId = entityId;
            this.entityType = entityType;
        }

        public object EntityId
        {
            get { return this.entityId; }
        }

        public string EntityType
        {
            get { return this.entityType; }
        }

    }
}
