using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.BasicInfo;


namespace SchoolManager.ViewModel._Basic.DivisionVMs
{
    public partial class DivisionBatchVM : BaseBatchVM<Division, Division_BatchEdit>
    {
        public DivisionBatchVM()
        {
            ListVM = new DivisionListVM();
            LinkedVM = new Division_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Division_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
