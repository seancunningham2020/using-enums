using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Web.Mvc;
using UsingEnums.Models;

namespace UsingEnums.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // Load enum values into dictionary, making use of the enum description decorations
            var userActionDictionary = new Dictionary<int, string>();
            foreach (var item in Enum.GetValues(typeof(UserActions)))
            {
                var reqValue = GetEnumValue<UserActions>(item.ToString());
                var actionDescription = GetEnumDescription(reqValue);

                userActionDictionary.Add((int)item, actionDescription);
            }

            var viewModel = new MainPageViewModel
            {
                SelectedUserAction = 0,
                UserActions = new SelectList(userActionDictionary, "Key", "Value")
            };

            return View(viewModel);
        }

        private T GetEnumValue<T>(string str) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new Exception("T must be an Enumeration type.");
            }
            T val = ((T[])Enum.GetValues(typeof(T)))[0];
            if (!string.IsNullOrEmpty(str))
            {
                foreach (T enumValue in (T[])Enum.GetValues(typeof(T)))
                {
                    if (enumValue.ToString().ToUpper().Equals(str.ToUpper()))
                    {
                        val = enumValue;
                        break;
                    }
                }
            }

            return val;
        }

        private string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}