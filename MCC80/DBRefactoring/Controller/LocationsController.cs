using DBRefactoring.Model;
using DBRefactoring.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRefactoring.Controller
{
    public class LocationsController
    {
        private Locations _locationsModel;
        private VLocations _locationsView;

        public LocationsController(Locations locationsModel, VLocations locationsView)
        {
            _locationsModel = locationsModel;
            _locationsView = locationsView;
        }

        public void GetAll()
        {
            var result = _locationsModel.GetAll();
            if (result.Count is 0)
            {
                _locationsView.DataEmpty();
            }
            else
            {
                _locationsView.GetAll(result);
            }
        }
        public void Insert()
        {
            var locations = _locationsView.InsertMenu();
            var result = _locationsModel.Insert(locations);

            switch (result)
            {
                case -1:
                    _locationsView.Error();
                    break;
                case 0:
                    _locationsView.Failure();
                    break;
                default:
                    _locationsView.Success();
                    break;
            }
        }

        public void Update()
        {
            var locations = _locationsView.UpdateMenu();
            var result = _locationsModel.Update(locations);

            switch (result)
            {
                case -1:
                    _locationsView.Error();
                    break;
                case 0:
                    _locationsView.Failure();
                    break;
                default:
                    _locationsView.Success();
                    break;
            }
        }

        public void Delete()
        {
            var locations = _locationsView.LocationsId();
            var result = _locationsModel.Delete(locations);

            switch (result)
            {
                case -1:
                    _locationsView.Error();
                    break;
                case 0:
                    _locationsView.Failure();
                    break;
                default:
                    _locationsView.Success();
                    break;
            }
        }

        public void GetById()
        {
            var locations = _locationsView.LocationsId();
            var result = _locationsModel.GetById(locations);

            if (result != null)
            {
                _locationsView.GetById(result);
            }
            else
            {
                _locationsView.DataEmpty();
            }
        }
    }
}
