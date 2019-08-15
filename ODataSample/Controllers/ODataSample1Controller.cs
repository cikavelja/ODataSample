using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using ODataSample.Models;

namespace ODataSample.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using ODataSample.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<ODataSample1>("ODataSample1");
    builder.EntitySet<ODataSample2>("ODataSample2"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ODataSample1Controller : ODataController
    {
        private Entities db = new Entities();

        // GET: odata/ODataSample1
        [EnableQuery(MaxExpansionDepth = 4)]
        public IQueryable<ODataSample1> GetODataSample1()
        {
            return db.ODataSample1;
        }

        // GET: odata/ODataSample1(5)
        [EnableQuery]
        public SingleResult<ODataSample1> GetODataSample1([FromODataUri] int key)
        {
            return SingleResult.Create(db.ODataSample1.Where(oDataSample1 => oDataSample1.ODataSample1Id == key));
        }

        // PUT: odata/ODataSample1(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<ODataSample1> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ODataSample1 oDataSample1 = await db.ODataSample1.FindAsync(key);
            if (oDataSample1 == null)
            {
                return NotFound();
            }

            patch.Put(oDataSample1);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ODataSample1Exists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(oDataSample1);
        }

        // POST: odata/ODataSample1
        public async Task<IHttpActionResult> Post(ODataSample1 oDataSample1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ODataSample1.Add(oDataSample1);
            await db.SaveChangesAsync();

            return Created(oDataSample1);
        }

        // PATCH: odata/ODataSample1(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<ODataSample1> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ODataSample1 oDataSample1 = await db.ODataSample1.FindAsync(key);
            if (oDataSample1 == null)
            {
                return NotFound();
            }

            patch.Patch(oDataSample1);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ODataSample1Exists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(oDataSample1);
        }

        // DELETE: odata/ODataSample1(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            ODataSample1 oDataSample1 = await db.ODataSample1.FindAsync(key);
            if (oDataSample1 == null)
            {
                return NotFound();
            }

            db.ODataSample1.Remove(oDataSample1);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ODataSample1(5)/ODataSample2
        [EnableQuery]
        public IQueryable<ODataSample2> GetODataSample2([FromODataUri] int key)
        {
            return db.ODataSample1.Where(m => m.ODataSample1Id == key).SelectMany(m => m.ODataSample2);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ODataSample1Exists(int key)
        {
            return db.ODataSample1.Count(e => e.ODataSample1Id == key) > 0;
        }
    }
}
