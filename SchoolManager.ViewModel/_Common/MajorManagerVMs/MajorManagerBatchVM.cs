using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.MajorMiddleInfo;


namespace SchoolManager.ViewModel._Common.MajorManagerVMs
{
    public partial class MajorManagerBatchVM : BaseBatchVM<MajorManager, MajorManager_BatchEdit>
    {
        public MajorManagerBatchVM()
        {
            ListVM = new MajorManagerListVM();
            LinkedVM = new MajorManager_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class MajorManager_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
