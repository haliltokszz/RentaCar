using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Core.Utilities.FileUploads;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [CacheAspect]
        public async Task<IDataResult<CarImage>> Get(string id)
        {
            var result = await _carImageDal.GetAsync(c => c.Id == id);

            IfCarImageOfCarNotExistsAddDefault(ref result);

            return new SuccessDataResult<CarImage>(result);
        }

        [SecuredOperation("carimage.getall,moderator,admin")]
        public async Task<IDataResult<List<CarImage>>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(await _carImageDal.GetAllAsync());
        }

        [CacheAspect]
        public async Task<IDataResult<List<CarImage>>> GetImagesByCar(string carId)
        {
            var result = await _carImageDal.GetAllAsync(c => c.CarId == carId);

            if (result.Count <= 0)
                result.Add(new CarImage
                {
                    ImagePath =
                        $@"{Environment.CurrentDirectory}\Public\Images\CarImage\default-img.png",
                    Date = DateTime.UtcNow
                });

            return new SuccessDataResult<List<CarImage>>(result);
        }

        [SecuredOperation("carimage.add,moderator,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public async Task<IResult> Add(CarImage carImage, IFormFile file)
        {
            var result = BusinessRules.Run(
                 await CheckCarImagesCount(carImage.CarId));
            if (result != null) return result;

            carImage.ImagePath = FileUpload.Upload(file).Message;
            carImage.Date = DateTime.Now;
            await _carImageDal.AddAsync(carImage);

            return new SuccessResult(Messages.CarImageAdded);
        }

        [SecuredOperation("carimage.update,moderator,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public async Task<IResult> Update(CarImage carImage, IFormFile file)
        {
            var carImageToUpdate = await _carImageDal.GetAsync(c => c.Id == carImage.Id);
            carImage.CarId = carImageToUpdate.CarId;
            carImage.ImagePath = FileUpload.Update(file, carImageToUpdate.ImagePath).Message;
            carImage.Date = DateTime.Now;
            await _carImageDal.UpdateAsync(carImage);

            return new SuccessResult(Messages.CarImageUpdated);
        }

        [SecuredOperation("carimage.delete,moderator,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        public async Task<IResult> Delete(CarImage carImage)
        {
            FileUpload.Delete(carImage.ImagePath);
            await _carImageDal.DeleteAsync(carImage);

            return new SuccessResult(Messages.CarImageDeleted);
        }

        private void IfCarImageOfCarNotExistsAddDefault(ref List<CarImage> result)
        {
            if (!result.Any()) result.Add(CreateDefaultCarImage());
        }

        private void IfCarImageOfCarNotExistsAddDefault(ref CarImage result)
        {
            if (result == null) result = CreateDefaultCarImage();
        }

        private CarImage CreateDefaultCarImage()
        {
            var defaultCarImage = new CarImage
            {
                ImagePath =
                    $@"{Environment.CurrentDirectory}\Public\Images\CarImage\default-img.png",
                Date = DateTime.Now
            };

            return defaultCarImage;
        }

        private string CreateNewPath(IFormFile file)
        {
            var fileInfo = new FileInfo(file.FileName);
            var newPath =
                $@"{Environment.CurrentDirectory}\Public\Images\CarImage\Upload\{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{fileInfo.Extension}";

            return newPath;
        }

        private async Task<IResult> CheckCarImagesCount(string carId)
        {
            var result = (await _carImageDal.GetAllAsync(c => c.CarId == carId)).Count;
            if (result >= 5) return new ErrorResult(Messages.CarImageCountError);

            return new SuccessResult();
        }
    }
}