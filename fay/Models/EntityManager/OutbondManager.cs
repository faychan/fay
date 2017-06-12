using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using fay.Models.DB;
using fay.Models.ViewModel;

namespace fay.Models.EntityManager
{
    public class outbondManager
    {

        public void Addoutbond(addoutbondView m)
        {

            using (DemoEntities1 db = new DemoEntities1())
            {

                outbond mn = new outbond();
                mn.harga = m.harga;
                mn.keterangan = m.keterangan;

                db.outbonds.Add(mn);
                db.SaveChanges();

            }
        }

        public List<outbondProfileView> GetAlloutbonds()
        {
            List<outbondProfileView> outbonds = new List<outbondProfileView>();
            using (DemoEntities1 db = new DemoEntities1())
            {
                outbondProfileView MV;
                var outbond = db.outbonds.ToList();
                foreach (outbond m in db.outbonds)
                {
                    MV = new outbondProfileView();
                    MV.id_outbond = m.id_outbond;
                    MV.keterangan = m.keterangan;
                    MV.harga = (int)m.harga;
                   
                    outbonds.Add(MV);
                }
                return outbonds;
            }
        }
        public outbondDataView GetoutbondDataView()
        {
            outbondDataView MDV = new outbondDataView();
            List<outbondProfileView> outbonds = GetAlloutbonds();
            MDV.outbondProfile = outbonds;
            return MDV;
        }
    }
}