using Artemis.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Artemis.Web.Models
{
    public static class CarAdvertMapper
    {
        public static void MapTo(this CarAdvertViewModel vm, CarAdvert carAdvert)
        {
            carAdvert.Id = vm.Id;
            carAdvert.Title = vm.Title;
            carAdvert.Fuel = 0;
            carAdvert.Price = vm.Price;
            carAdvert.IsNew = vm.New;
            carAdvert.Mileage = vm.Mileage;
            carAdvert.FirstRegistration = vm.FirstRegistration;
        }

        public static CarAdvertViewModel MapToVm(this CarAdvert carAdvert)
        {
            var vm = new CarAdvertViewModel();
            vm.Id = carAdvert.Id;
            vm.Title = carAdvert.Title;
            vm.Fuel = "";
            vm.Price = carAdvert.Price;
            vm.New = carAdvert.IsNew;
            vm.Mileage = carAdvert.Mileage;
            vm.FirstRegistration = carAdvert.FirstRegistration;
            return vm;
        }
    }
}