﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartDataInitiative.Business.Interfaces;
using SmartDataInitiative.Business.Interfaces.Services;
using SmartDataInitiative.Business.Models;
using SmartDataInitiative.Data.Context;

namespace SmartDataInitiative.Api.v1.Controllers
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProjectsController : MainController
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;


        public ProjectsController(INotify notify,
                                  IProjectService projectService, 
                                  IMapper mapper) : base(notify)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Project>> All() => _mapper.Map<IEnumerable<Project>>(await _projectService.All());
        
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Project>> Show(Guid id)
        {
            var project = await GetProject(id);

            if (project == null) return BadRequest();

            return project;
        }









        private async Task<Project> GetProject(Guid id) => _mapper.Map<Project>(await _projectService.Show(id));






        //private readonly MyDbContext _context;

        //public ProjectsController(MyDbContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/Projects
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        //{
        //    return await _context.Projects.ToListAsync();
        //}

        //// GET: api/Projects/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Project>> GetProject(Guid id)
        //{
        //    var project = await _context.Projects.FindAsync(id);

        //    if (project == null)
        //    {
        //        return NotFound();
        //    }

        //    return project;
        //}

        //// PUT: api/Projects/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProject(Guid id, Project project)
        //{
        //    if (id != project.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(project).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProjectExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Projects
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Project>> PostProject(Project project)
        //{
        //    _context.Projects.Add(project);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetProject", new { id = project.Id }, project);
        //}

        //// DELETE: api/Projects/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Project>> DeleteProject(Guid id)
        //{
        //    var project = await _context.Projects.FindAsync(id);
        //    if (project == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Projects.Remove(project);
        //    await _context.SaveChangesAsync();

        //    return project;
        //}

        //private bool ProjectExists(Guid id)
        //{
        //    return _context.Projects.Any(e => e.Id == id);
        //}

    }
}