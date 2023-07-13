using DBRefactoring.Model;
using DBRefactoring.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRefactoring.Controller
{
    public class HistoryController
    {
        private History _hisModel;
        private VHistories _hisView;

        public HistoryController(History hisModel, VHistories hisView)
        {
            _hisModel = hisModel;
            _hisView = hisView;
        }

        public void GetAll()
        {
            var result = _hisModel.GetAll();
            if (result.Count is 0)
            {
                _hisView.DataEmpty();
            }
            else
            {
                _hisView.GetAll(result);
            }
        }
        public void Insert()
        {
            var department = _hisView.InsertMenu();
            var result = _hisModel.Insert(department);

            switch (result)
            {
                case -1:
                    _hisView.Error();
                    break;
                case 0:
                    _hisView.Failure();
                    break;
                default:
                    _hisView.Success();
                    break;
            }
        }

        public void Update()
        {
            var department = _hisView.UpdateMenu();
            var result = _hisModel.Update(department);

            switch (result)
            {
                case -1:
                    _hisView.Error();
                    break;
                case 0:
                    _hisView.Failure();
                    break;
                default:
                    _hisView.Success();
                    break;
            }
        }

        public void Delete()
        {
            var department = _hisView.HistoryId();
            var result = _hisModel.Delete(department);

            switch (result)
            {
                case -1:
                    _hisView.Error();
                    break;
                case 0:
                    _hisView.Failure();
                    break;
                default:
                    _hisView.Success();
                    break;
            }
        }

        public void GetById()
        {
            var department = _hisView.HistoryId();
            var result = _hisModel.GetById(department);

            if (result != null)
            {
                _hisView.GetById(result);
            }
            else
            {
                _hisView.DataEmpty();
            }
        }

    }
}
