using DBRefactoring.Model;
using DBRefactoring.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRefactoring.Controller
{
    public class JobsController
    {
        private Jobs _jobModel;
        private VJobs _jobView;

        public JobsController(Jobs jobModel, VJobs jobView)
        {
            _jobModel = jobModel;
            _jobView = jobView;
        }

        public void GetAll()
        {
            var result = _jobModel.GetAll();
            if (result.Count is 0)
            {
                _jobView.DataEmpty();
            }
            else
            {
                _jobView.GetAll(result);
            }
        }
        public void Insert()
        {
            var department = _jobView.InsertMenu();
            var result = _jobModel.Insert(department);

            switch (result)
            {
                case -1:
                    _jobView.Error();
                    break;
                case 0:
                    _jobView.Failure();
                    break;
                default:
                    _jobView.Success();
                    break;
            }
        }

        public void Update()
        {
            var department = _jobView.UpdateMenu();
            var result = _jobModel.Update(department);

            switch (result)
            {
                case -1:
                    _jobView.Error();
                    break;
                case 0:
                    _jobView.Failure();
                    break;
                default:
                    _jobView.Success();
                    break;
            }
        }

        public void Delete()
        {
            var department = _jobView.JobsId();
            var result = _jobModel.Delete(department);

            switch (result)
            {
                case -1:
                    _jobView.Error();
                    break;
                case 0:
                    _jobView.Failure();
                    break;
                default:
                    _jobView.Success();
                    break;
            }
        }

        public void GetById()
        {
            var department = _jobView.JobsId();
            var result = _jobModel.GetById(department);

            if (result != null)
            {
                _jobView.GetById(result);
            }
            else
            {
                _jobView.DataEmpty();
            }
        }

    }
}
