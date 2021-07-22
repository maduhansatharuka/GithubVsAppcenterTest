using Assessment.Test.Models;
using Assessment.Test.Services.Interfaces;
using Assessment.Test.Utils;
using Assessment.Test.ViewModels;
using Assessment.Test.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(HomeViewModel))]
namespace Assessment.Test.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region Constructors & initialisation

        public HomeViewModel( IDiaryAPIService pdiaryAPIService)
        {
            ImageList = new ObservableCollection<ImageModel>();
            diaryAPIService = pdiaryAPIService;
            _constructor();
        }
        public HomeViewModel()
        {
            ImageList = new ObservableCollection<ImageModel>();
            diaryAPIService = DependencyService.Get<IDiaryAPIService>();
            _constructor();
        }
        private void _constructor()
        {
            EventList = new ObservableCollection<string>()
            {
                "Event 1",
                "Event 2",
                "Event 3",
            };
            TaskCategoryList = new ObservableCollection<string>()
            {
                "Task Category 1",
                "Task Category 2",
                "Task Category 3",
            };
            AreaList = new ObservableCollection<string>()
            {
                "Area 1",
                "Area 2",
                "Area 3",
            };

        }

        #endregion

        #region Services

        private readonly IDiaryAPIService diaryAPIService;

        #endregion


        #region Properties

        private ObservableCollection<ImageModel> _imageList ;
        public ObservableCollection<ImageModel> ImageList { get => _imageList; set => SetProperty(ref _imageList, value); }

        private ObservableCollection<string> _areaList ;
        public ObservableCollection<string> AreaList { get => _areaList; set => SetProperty(ref _areaList, value); }

        private ObservableCollection<string> _taskCategoryList;
        public ObservableCollection<string> TaskCategoryList { get => _taskCategoryList; set => SetProperty(ref _taskCategoryList, value); }

        private ObservableCollection<string> _eventList ;
        public ObservableCollection<string> EventList { get => _eventList; set => SetProperty(ref _eventList, value); }
        
        private string _area ;
        public string Area { get => _area; set => SetProperty(ref _area, value); }
        
        private string _event ;
        public string Event { get => _event; set => SetProperty(ref _event, value); }
        
        private DateTime _date = DateTime.Now;
        public DateTime Date { get => _date; set => SetProperty(ref _date, value); }

        private string _tags ;
        public string Tags { get => _tags; set => SetProperty(ref _tags, value); }

        private string _taskcategory ;
        public string Taskcategory { get => _taskcategory; set => SetProperty(ref _taskcategory, value); }

        private string _comments ;
        public string Comments { get => _comments; set => SetProperty(ref _comments, value); }
        
        private bool _linkToExistingEvent;
        public bool LinkToExistingEvent { get { return _linkToExistingEvent; } set { SetProperty(ref _linkToExistingEvent, value); } }
        
        private bool _includeInGallery;
        public bool IncludeInGallery { get { return _includeInGallery; } set { SetProperty(ref _includeInGallery, value); } }

        #endregion
        #region Commands

        private ICommand _addPhotoCommand = null;
        public ICommand AddPhotoCommand => _addPhotoCommand = _addPhotoCommand ?? new Command(async () => await DoAddPhotoCommand());
        
        private ICommand _removePhotoCommand = null;
        public ICommand RemovePhotoCommand => _removePhotoCommand = _removePhotoCommand ?? new Command<ImageModel>( (parameter) =>  DoRemovePhotoCommand(parameter));

        private ICommand _nextCommand = null;
        public ICommand NextCommand => _nextCommand = _nextCommand ?? new Command(async () => await DoNextCommand());

        #endregion

        #region Methods
        /// <summary>
        /// Wrapper method for remove image command
        /// </summary>
        /// <param name="image"></param>
        private void DoRemovePhotoCommand(ImageModel image) 
        {
            try
            {
                ImageList.Remove(image);
            }
            catch (Exception ex) 
            {
                errorHandlingService.LogException(ex);
            }
        }

        /// <summary>
        /// Wrapper method for add photo command
        /// </summary>
        /// <returns></returns>
        private async Task DoAddPhotoCommand() 
        {
            try
            {
                FileResult photo = await MediaPicker.PickPhotoAsync();
                if (photo != null)
                {
                    ImageModel image = new ImageModel();
                    Stream stream = await photo.OpenReadAsync();
                    image.ImageSource = ImageSource.FromStream(() => stream);
                    image.ImageBase64 = ConverterUtil.StreamTobase64(stream);
                    ImageList.Add(image);
                }
            }
            catch (PermissionException pEx)
            {
                await Application.Current.MainPage.DisplayAlert(AppConstants.Failed, AppConstants.PermissionFailedOpenGalery, AppConstants.Ok);
            }
            catch (Exception ex) 
            {
                errorHandlingService.LogException(ex);
            }
        }

        /// <summary>
        /// Wrapper method for do next command
        /// </summary>
        /// <returns></returns>
        private async Task DoNextCommand() 
        {
            try
            {
                await PostData();
            }
            catch (Exception ex)
            {
                errorHandlingService.LogException(ex);
            }
            
        }

        /// <summary>
        /// Method for post the data for diary API endpoint
        /// </summary>
        /// <returns></returns>
        private async Task PostData() 
        {
            if (ImageList?.Count > 0)
            {
                IsBusy = true;
                List<string> images = new List<string>();
                foreach (ImageModel image in _imageList)
                {
                    images.Add(image.ImageBase64);
                }
                DiaryModel diaryModel = new DiaryModel
                {
                    Images = images,
                    Area = _area,
                    Comments = _comments,
                    Tags = _tags,
                    TaskCategory = _taskcategory,
                    EventName = _event,
                    DiaryDate = _date,
                    LinkToExistingEvent = _linkToExistingEvent,
                    IncludeInGallery = _includeInGallery
                };

                try
                {
                    HttpResponseMessage response = await diaryAPIService.AddNewDiary(diaryModel);
                    if (response?.StatusCode == HttpStatusCode.Created)
                    {
                        await Application.Current.MainPage.DisplayAlert(AppConstants.Success, AppConstants.SuccessDairyUpload, AppConstants.Ok);
                        ClearFormData();
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert(AppConstants.Success, AppConstants.SuccessDairyUpload, AppConstants.Ok);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    IsBusy = false;
                }
            }
            else 
            {
                await Application.Current.MainPage.DisplayAlert(AppConstants.Failed, AppConstants.EmptyImagesError, AppConstants.Ok);
            }
        }

        private void ClearFormData() 
        {
            ImageList = new ObservableCollection<ImageModel>();
            Date = DateTime.Now;
            Area = String.Empty;
            Tags = String.Empty;
            Comments = String.Empty;
            Taskcategory = String.Empty;
            Event = String.Empty;
            IncludeInGallery = false;
            LinkToExistingEvent = false;

        }
        
        #endregion

    }
}
