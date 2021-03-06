﻿using Microsoft.EntityFrameworkCore;
using ApiRestful.Business.Interfaces;
using ApiRestful.Business.Models;
using ApiRestful.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestful.Data.Repository
{
    public class FieldRespository : Repository<Field>, IFieldRepository
    {
        public FieldRespository(MyDbContext context) : base(context) { }

        public async Task<Field> GetReportsInField(Guid id) => await
                   Db.Fields.AsNoTracking()
                   .Include(c => c.Reports)
                   .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Field> GetFeedbacksInField(Guid id) => await
                    Db.Fields.AsNoTracking()
                    .Include(c => c.Feedbacks)
                    .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<IEnumerable<Field>> GetFieldsByProject(Guid ProjectId) => await
                    Db.Fields.AsNoTracking()
                    .Where(c => c.ProjectId == ProjectId)
                    .ToListAsync();

        public async Task<Field> GetAllInField(Guid id) => await
                  Db.Fields.AsNoTracking()
                  .Include(c => c.Reports)
                  .Include(c => c.Feedbacks)
                  .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<IEnumerable<Field>> GetAllFields() => await
               Db.Fields.AsNoTracking()
               .Include(c => c.Reports)
               .Include(c => c.Feedbacks)
               .ToListAsync();

    }
}
