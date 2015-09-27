using System.Web.Http;
using Ticket_Now.Repository.Dtos;
using Ticket_Now.Repository.Models;
using Ticket_Now.Repository.Repositories;

namespace Ticket_Now.Authentication.Controllers
{
    [RoutePrefix("api/audience")]
    public class AudienceController : ApiController
    {
        [Route("")]
        public IHttpActionResult Post(AudienceModel audienceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Audience newAudience = AudiencesStore.AddAudience(audienceModel.Name);

            return Ok(newAudience);

        }
    }
}
