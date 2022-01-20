using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectB.Services
{
    class CreateDataService
    {
        public void InsertData<T>(object entity)
        {
            using (PrivateSchool db = new PrivateSchool())
            {
                Type tType = typeof(T);
                var add = db.Set(tType);
                add.Add(entity);
                db.SaveChanges();
            }
        }
    }
}
