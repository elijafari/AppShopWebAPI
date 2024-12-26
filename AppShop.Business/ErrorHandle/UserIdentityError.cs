using AppShop.Business.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.ErrorHandle
{
    public class UserIdentityError : IdentityErrorDescriber
    {

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError()
            {
                Code = nameof(DuplicateEmail),
                Description = string.Format("پست الکترونیکی وارد شده تکراری است.", email)
            };
        }

        public override IdentityError DuplicateUserName(string userName)
        {

            return new IdentityError()
            {
                Code = nameof(DuplicateEmail),
                Description = string.Format("نام کاربری وارد شده تکراری است", userName)
            };
        }
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresDigit),
                Description = string.Format("رمز عبور فاقد کاراکتر عددی است")
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = string.Format("رمز عبور فاقد کاراکتر حرفی است")
            };
        }
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = nameof(PasswordTooShort),
                Description = string.Format("رمز عبور حداقل 4 باشد")
            };
        }
    }
}
