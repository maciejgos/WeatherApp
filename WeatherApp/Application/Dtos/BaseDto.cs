using System;
namespace WeatherApp.Application.Dtos
{
    public class BaseDto
    {
        public virtual T MapToModel<T>() where T : class, new() => throw new NotImplementedException("Method needs to be implemented.");
    }
}
