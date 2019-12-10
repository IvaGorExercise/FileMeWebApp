using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Web;
using System.Web.Security;

namespace FileMe.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "USER NAME")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "PASSWORD")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    //public class RegisterModel
    //{
    //    [Required]
    //    [Display(Name = "User name")]
    //    public string UserName { get; set; }

    //    [Required]
    //    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    //    [DataType(DataType.Password)]
    //    [Display(Name = "Password")]
    //    public string Password { get; set; }

    //    [DataType(DataType.Password)]
    //    [Display(Name = "Confirm password")]
    //    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    //    public string ConfirmPassword { get; set; }
    //}

    public class RegisterModel
    {
        [Required]
        [Display(Name = "Korisničko ime")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Polje {0} mora imati najmanje {2} znaka dugo.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdi lozinku")]
        [Compare("Password", ErrorMessage = "Polja lozinka i potvrda lozinke nisu identična.")]
        public string ConfirmPassword { get; set; }

  
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Ime")]
        public string Ime { get; set; }

        [Display(Name = "Prezime")]
        public string Prezime { get; set; }

        public string InitialPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }

    public class Pitanje
    {

        [Display(Name = "IME")]
        public string Ime { get; set; }

        [Display(Name = "PREZIME")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Email je obavezan.")]
        [Display(Name = "EMAIL*")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail nije ispravan")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Unesite tekst poruke.")]
        [Display(Name = "PORUKA*")]
        public string PitanjeTekst { get; set; }

        [Display(Name = "(Slika .png, .jpg, .gif, .bmp format do 5 MB)  ")]
        public string Slika { get; set; }


        [Display(Name = "TAG")]
        public string Tag { get; set; }

        [ValidateFile(ErrorMessage = "Izaberite sliku .png, .jpg, .gif, ili .bmp formata manju od 5 MB")]
        public HttpPostedFileBase File { get; set; }

        public string SuccessMessage { get; set; }
      
    }

    public class ValidateFileAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file == null)
            {
                return true;
            }

            if (file.ContentLength > 5 * 1024 * 1024)
            {
                return false;
            }

            try
            {
                using (var img = Image.FromStream(file.InputStream))
                {
                    if (img.RawFormat.Equals(ImageFormat.Png))
                    {
                        return true;
                    }

                    else if (img.RawFormat.Equals(ImageFormat.Jpeg))
                    {
                        return true;
                    }

                    else if (img.RawFormat.Equals(ImageFormat.Gif))
                    {
                        return true;
                    }

                    else if (img.RawFormat.Equals(ImageFormat.Bmp))
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }

                }
            }
            catch { }
            return false;
        }
    }

    public class PitanjeVM
    {

        public int ID_Pitanje { get; set; }

        [Display(Name = "Ime")]
        public string Ime { get; set; }

        [Display(Name = "Prezime")]
        public string Prezime { get; set; }

        [Required]
        [Display(Name = "Email*")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail nije ispravan")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Pitanje*")]
        public string PitanjeTekst { get; set; }

        [Display(Name = "Slika (.png, .jpg, .gif, .bmp do 5 MB)")]
        public string Slika { get; set; }

        [Display(Name = "Tag")]
        public string Tag { get; set; }

        [Display(Name = "Pročitano")]
        public bool Procitano { get; set; }

        [Display(Name = "Odgovoreno")]
        public bool Odgovoreno { get; set; }

        [Display(Name = "Komentar")]
        public string Komentar { get; set; }

        [Display(Name = "Datum pitanja")]
        public Nullable<System.DateTime> DatumPitanja { get; set; }

        [Display(Name = "Datum odgovora")]
        public Nullable<System.DateTime> DatumOdgovora { get; set; }

        [Display(Name = "Odgovor")]
        public string Odgovor { get; set; }

  

    }
}
