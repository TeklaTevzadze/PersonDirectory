using Microsoft.AspNetCore.Mvc;
using PersonDirectory.Application.Features.Persons.Commands.CreatePersonCommand;
using PersonDirectory.Application.Features.Persons.Commands.DeletePersonCommand;
using PersonDirectory.Application.Features.Persons.Commands.UpdatePersonCommand;
using PersonDirectory.Application.Features.Persons.Queries.GetPersonQuery;
using PersonDirectory.Application.Features.Persons.Queries.GetPersonsQuery;
using System.Threading.Tasks;

namespace PersonDirectory.Api.Controllers
{
    public class PersonController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePersonCommand command) => Ok(await Mediator.Send(command));

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePersonCommand command) => Ok(await Mediator.Send(command));

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeletePersonCommand command) => Ok(await Mediator.Send(command));

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPerson(int id) => Ok(await Mediator.Send(new GetPersonQuery { Id = id }));

        [HttpGet]
        public async Task<IActionResult> GetPersons([FromQuery] GetPersonsQuery query) => Ok(await Mediator.Send(query));
    }
}
