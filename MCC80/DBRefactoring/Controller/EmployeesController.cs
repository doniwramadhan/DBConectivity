using DBRefactoring.Model;
using DBRefactoring.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRefactoring.Controller
{
    public class EmployeesController
    {
        private Employees _empModel;
        private VEmployees _empView;

        public EmployeesController(Employees empModel, VEmployees empView)
        {
            _empModel = empModel;
            _empView = empView;
        }

        public void GetAll()
        {
            var result = _empModel.GetAll();
            if (result.Count is 0)
            {
                _empView.DataEmpty();
            }
            else
            {
                _empView.GetAll(result);
            }
        }
        public void Insert()
        {
            var department = _empView.InsertMenu();
            var result = _empModel.Insert(department);

            switch (result)
            {
                case -1:
                    _empView.Error();
                    break;
                case 0:
                    _empView.Failure();
                    break;
                default:
                    _empView.Success();
                    break;
            }
        }

        public void Update()
        {
            var department = _empView.UpdateMenu();
            var result = _empModel.Update(department);

            switch (result)
            {
                case -1:
                    _empView.Error();
                    break;
                case 0:
                    _empView.Failure();
                    break;
                default:
                    _empView.Success();
                    break;
            }
        }

        public void Delete()
        {
            var department = _empView.EmployeesId();
            var result = _empModel.Delete(department);

            switch (result)
            {
                case -1:
                    _empView.Error();
                    break;
                case 0:
                    _empView.Failure();
                    break;
                default:
                    _empView.Success();
                    break;
            }
        }

        public void GetById()
        {
            var department = _empView.EmployeesId();
            var result = _empModel.GetById(department);

            if (result != null)
            {
                _empView.GetById(result);
            }
            else
            {
                _empView.DataEmpty();
            }
        }
    }
}
