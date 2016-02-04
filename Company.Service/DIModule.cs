﻿using Company.Service.Common;


namespace Company.Service
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        /// <summary>
        /// Load modules into kernel
        /// </summary>
        public override void Load()
        {

            Bind<IDepartmentService>().To<DepartmentService>();
            Bind<IEmployeeService>().To<EmployeeService>();

        }
    }
}