using System;
using Earth_In_Beats.WebService.DAL.Contracts.Models;
using FluentValidation;

namespace Earth_In_Beats.WebService.Business.Implementation.Validation
{
    public class DeviceContextEntityValidator : AbstractValidator<DeviceContextEntity>, IValidator<DeviceContextEntity>
    {
        public DeviceContextEntityValidator()
        {
            RuleFor(device => device.Id).
                NotEmpty().WithMessage(Require(nameof(DeviceContextEntity.Id)));

            RuleFor(device => device.Created).
                NotEmpty().WithMessage(Require(nameof(DeviceContextEntity.Created)));

            RuleFor(device => device.Status).
                NotEmpty().WithMessage(Require(nameof(DeviceContextEntity.Status))).
                IsInEnum().WithMessage("Not existed device status.");

            RuleFor(device => device.DeviceKey).
                Must(BeValideDeviceKey).WithMessage($"Field {nameof(DeviceContextEntity.DeviceKey)} should be correct device key.");

            RuleFor(device => device.Latitude).
                Must(BeLatitude).WithMessage("Input correct latitude.");

            RuleFor(device => device.Longitude).
                Must(BeLongitude).WithMessage("Input correct longitude.");
        }

        private string Require(string fieldName)
        {
            return $"Field {fieldName} is require.";
        }

        private bool BeLongitude(double longitude)
        {
            return longitude >= 0 || longitude <= 180;
        }

        private bool BeLatitude(double latitude)
        {
            return latitude >= -90 || latitude <= 90;
        }

        private bool BeValideDeviceKey(string deviceKey)
        {
            //@todo: add logic for device key validation.
            return true;
        }

        string[] IValidator<DeviceContextEntity>.Validate(DeviceContextEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
