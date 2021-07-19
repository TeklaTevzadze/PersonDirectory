using Microsoft.AspNetCore.Mvc;
using PersonDirectory.Application.Features.PersonRelationships.Commands.CreatePersonRelationshipCommand;
using PersonDirectory.Application.Features.PersonRelationships.Commands.DeletePersonRelationshipCommand;
using System.Threading.Tasks;

namespace PersonDirectory.Api.Controllers
{
    public class PersonRelationshipController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePersonRelationshipCommand command) => Ok(await Mediator.Send(command));

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeletePersonRelationshipCommand command) => Ok(await Mediator.Send(command));
    }
}
