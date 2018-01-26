using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MonsterWebApp.Models
{
    public class UserWeapon
    {
        public int ID { get; set; }

        [Required, StringLength(25)]
        public int WeaponID { get; set; }

        [Required, StringLength(50)]
        public int UserID { get; set; }

        [Required, StringLength(25)]
        public string WeaponName { get; set; }

        [Required, StringLength(50)]
        public string UserName { get; set; }
    }
}
