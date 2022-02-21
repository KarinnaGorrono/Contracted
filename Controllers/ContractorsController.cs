using System;
using System.Collections.Generic;
using Contractors.Models;
using Contractors.Services;
using Microsoft.AspNetCore.Mvc;

namespace contractor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ContractorsController : ControllerBase
    {
        private readonly ContractorsService _cs;

        public ContractorsController(ContractorsService cs)
        {
            _cs = cs;
        }
        [HttpGet]

        public ActionResult<IEnumerable<Contractor>> Get()
        {
            try
            {
                var contract = _cs.Get();
                return Ok(contract);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id")]

        public ActionResult<Contractor> Get(int id)
        {
            try
            {
                var contract = _cs.Get(id);
                return Ok(contract);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Authorize]

        public async Task<ActionResult<Contractor>>
    }
}