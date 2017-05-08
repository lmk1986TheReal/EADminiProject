// a RESTful services which provides stock market prices for stocks and allows updates and deletes (CRUD)
// data stored in a LocalDB database using Entity Framework Code First under app_data
// /swagger for UI test page

using System.Web.Http;
using System.Linq;
using EADMiniProject.DAL;

namespace EADMiniProject.Controllers
{
    public class ClientApiController : ApiController
    {

        private ArtistContext db = new ArtistContext();

        // GET api/operation
        public IHttpActionResult GetAllListings()
        {
            if (db.Bands.Count() == 0)
            {
                return NotFound();
            }

            else
            {
                return Ok(db.Bands.OrderBy(s => s.BandName).ToList());       // 200 OK, listings serialized in response body 
            }
        }


    }

}