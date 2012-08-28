﻿using System.Linq;
using System.Data.Objects;

namespace SampleApp.ExampleData
{
    public class ProjectRepository : GenericRepository<Project>
    {
        public ProjectRepository(ObjectContext context) : base(context)
        {
        }

        public override void Delete(Project entity)
        {
            entity.Tasks.SelectMany(t => t.Works).ToList().Clear();
            entity.Tasks.Clear();
            base.Delete(entity);
        }
    }
}
