using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using SchoolManager.Model.Business;


namespace SchoolManager.ViewModel._Common.TeacherMajorManagerVMs
{
    public partial class TeacherMajorManagerBatchVM : BaseBatchVM<TeacherMajorManager, TeacherMajorManager_BatchEdit>
    {
        public TeacherMajorManagerBatchVM()
        {
            ListVM = new TeacherMajorManagerListVM();
            LinkedVM = new TeacherMajorManager_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class TeacherMajorManager_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
