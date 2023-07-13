using DBRefactoring.Model;
using DBRefactoring.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRefactoring.Controller
{
    public class RegionsController
    {
        private Regions _regionModel;
        private VRegions _regionsView;

        public RegionsController(Regions regionModel, VRegions regionsView)
        {
            _regionModel = regionModel;
            _regionsView = regionsView;
        }

        public void GetAll()
        {
            var result = _regionModel.GetAll();
            if (result.Count is 0)
            {
                _regionsView.DataEmpty();
            }
            else
            {
                _regionsView.GetAll(result);
            }
        }
        public void Insert()
        {
            var regions = _regionsView.InsertMenu();
            var result = _regionModel.Insert(regions);

            switch (result)
            {
                case -1:
                    _regionsView.Error();
                    break;
                case 0:
                    _regionsView.Failure();
                    break;
                default:
                    _regionsView.Success();
                    break;
            }
        }

        public void Update()
        {
            var regions = _regionsView.UpdateMenu();
            var result = _regionModel.Update(regions);

            switch (result)
            {
                case -1:
                    _regionsView.Error();
                    break;
                case 0:
                    _regionsView.Failure();
                    break;
                default:
                    _regionsView.Success();
                    break;
            }
        }

        public void Delete()
        {
            var regions = _regionsView.RegionsId();
            var result = _regionModel.Delete(regions);

            switch (result)
            {
                case -1:
                    _regionsView.Error();
                    break;
                case 0:
                    _regionsView.Failure();
                    break;
                default:
                    _regionsView.Success();
                    break;
            }
        }

        public void GetById()
        {
            var regions = _regionsView.RegionsId();
            var result = _regionModel.GetById(regions);
            
            if (result != null)
            {
                _regionsView.GetById(result);
            }
            else
            {
                _regionsView.DataEmpty();
            }
        }
    }
}
