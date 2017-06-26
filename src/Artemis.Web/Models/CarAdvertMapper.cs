using Artemis.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Artemis.Web.Models
{
    public static class CarAdvertMapper
    {
        public static bool MapTo(this CarAdvertViewModel vm, CarAdvert carAdvert)
        {
            if (vm.New && (vm.Mileage != null || vm.FirstRegistration != null))
            {
                return false;
            }

            var fuelType = vm.Fuel?.ToLower();

            if (fuelType != CarAdvertViewModel.FuelGasoline &&
                fuelType != CarAdvertViewModel.FuelDiesel)
            {
                return false;
            }

            carAdvert.Id = vm.Id;
            carAdvert.Title = vm.Title;
            carAdvert.Fuel = fuelType == CarAdvertViewModel.FuelGasoline
                ? FuelType.Gasoline
                : FuelType.Diesel;
            carAdvert.Price = vm.Price;
            carAdvert.IsNew = vm.New;
            carAdvert.Mileage = vm.Mileage;
            carAdvert.FirstRegistration = vm.FirstRegistration;
            return true;
        }

        public static CarAdvertViewModel MapToVm(this CarAdvert carAdvert)
        {
            var vm = new CarAdvertViewModel();
            vm.Id = carAdvert.Id;
            vm.Title = carAdvert.Title;
            vm.Fuel = carAdvert.Fuel == FuelType.Gasoline
                ? CarAdvertViewModel.FuelGasoline
                : CarAdvertViewModel.FuelDiesel;
            vm.Price = carAdvert.Price;
            vm.New = carAdvert.IsNew;
            vm.Mileage = carAdvert.Mileage;
            vm.FirstRegistration = carAdvert.FirstRegistration;
            return vm;
        }
    }
}