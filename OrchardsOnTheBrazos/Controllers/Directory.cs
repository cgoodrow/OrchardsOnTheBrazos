using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using PagedList;
using OrchardsOnTheBrazos.Models;
using System.Net;

namespace OrchardsOnTheBrazos.Controllers
{
    public class DirectoryController : Controller
    {
        private ApplicationUserManager _userManager;

        // Controllers

        // GET: /Admin/
        [Authorize(Roles = "Resident")]
        #region public ActionResult Index(string searchStringUserNameOrEmail)
        public ActionResult Index(string searchStringUserNameOrEmail, string currentFilter, int? page, RegisterViewModel model)
        {
            try
            {
                int intPage = 1;
                int intPageSize = 5;
                int intTotalPageCount = 0;

                if (searchStringUserNameOrEmail != null)
                {
                    intPage = 1;
                }
                else
                {
                    if (currentFilter != null)
                    {
                        searchStringUserNameOrEmail = currentFilter;
                        intPage = page ?? 1;
                    }
                    else
                    {
                        searchStringUserNameOrEmail = "";
                        intPage = page ?? 1;
                    }
                }

                ViewBag.CurrentFilter = searchStringUserNameOrEmail;

                List<ExpandedUserDTO> col_UserDTO = new List<ExpandedUserDTO>();
                int intSkip = (intPage - 1) * intPageSize;

                intTotalPageCount = UserManager.Users
                    .Where(x => x.UserName.Contains(searchStringUserNameOrEmail))
                    .Count();
                //.Where(x => x.LastName.Contains(searchStringUserNameOrEmail)).Count();

                var result = UserManager.Users
                    .Where(x => x.UserName.Contains(searchStringUserNameOrEmail))
                    .OrderBy(x => x.UserName)
                    //.Where(x => x.LastName.Contains(searchStringUserNameOrEmail))
                    //.OrderBy(x => x.LastName)
                    .Skip(intSkip)
                    .Take(intPageSize)
                    .ToList();

                foreach (var item in result)
                {
                    ExpandedUserDTO objUserDTO = new ExpandedUserDTO();

                    objUserDTO.FirstName = item.FirstName;
                    objUserDTO.LastName = item.LastName;
                    objUserDTO.UserName = item.UserName;
                    objUserDTO.Email = item.Email;
                    objUserDTO.LockoutEndDateUtc = item.LockoutEndDateUtc;

                    col_UserDTO.Add(objUserDTO);
                }

                // Set the number of pages
                var _UserDTOAsIPagedList =
                    new StaticPagedList<ExpandedUserDTO>
                    (
                        col_UserDTO, intPage, intPageSize, intTotalPageCount
                        );

                return View(_UserDTOAsIPagedList);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error: " + ex);
                List<ExpandedUserDTO> col_UserDTO = new List<ExpandedUserDTO>();

                return View(col_UserDTO.ToPagedList(1, 25));
            }
        }
        #endregion

        // Users *****************************

     
        // Utility

        #region public ApplicationUserManager UserManager
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ??
                    HttpContext.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        #endregion

        #region private ExpandedUserDTO GetUser(string paramUserName)
        private ExpandedUserDTO GetUser(string paramUserName)
        {
            ExpandedUserDTO objExpandedUserDTO = new ExpandedUserDTO();

            var result = UserManager.FindByName(paramUserName);

            // If we could not find the user, throw an exception
            if (result == null) throw new Exception("Could not find the User");

            objExpandedUserDTO.UserName = result.UserName;
            objExpandedUserDTO.Email = result.Email;
            objExpandedUserDTO.LockoutEndDateUtc = result.LockoutEndDateUtc;
            objExpandedUserDTO.AccessFailedCount = result.AccessFailedCount;
            objExpandedUserDTO.PhoneNumber = result.PhoneNumber;

            return objExpandedUserDTO;
        }
        #endregion
        
    }
}