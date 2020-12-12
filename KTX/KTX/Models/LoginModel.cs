using Models.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KTX.Models
{
    public class LoginModel
    {
        private DBKTX db;

        public LoginModel()
        {
            db = new DBKTX();
        }
      
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }

        
        public NGUOIDUNG login(string user, string pass)
        {
            var result = db.NGUOIDUNGs.SingleOrDefault(x => x.TenDangNhap.Equals(user)
                && x.MatKhau.Equals(pass));
            if (result != null)
            {
                return result;
            }
            return null;

        } 
    }
}