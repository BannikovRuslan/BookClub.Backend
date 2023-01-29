using ICSSoft.STORMNET;
using System;

namespace BookClub.Domains
{
    /// <summary>
    /// Presentation.
    /// </summary>
    // *** Start programmer edit section *** (Presentation CustomAttributes)
    // *** End programmer edit section *** (Presentation CustomAttributes)
    [PrimaryKeyStorage("Id")]
    [AutoAltered()]
    [AccessType(AccessType.none)]
    [View("PresentationE", new string[] {
            "Id as \'Id\'",
            "Date as \'Date\'",
            "Rating as \'Rating\'",
            "UrlPresentation as \'Url presentation\'",
            "UrlVideo as \'Url video\'",
            "Review as \'Review\'",
            "Speaker as \'Speaker\'",
            "Speaker.FirstName as \'First name\'",
            "Book as \'Book\'",
            "Book.Title as \'Title\'"}, Hidden = new string[] {
            "Speaker.FirstName",
            "Book.Title"})]
    [MasterViewDefineAttribute("PresentationE", "Speaker", LookupTypeEnum.Standard, "", "Id")]
    [MasterViewDefineAttribute("PresentationE", "Book", LookupTypeEnum.Standard, "", "Id")]
    public class Presentation : DataObject
    {
        private Guid fId;
        private DateTime fDate;
        private int fRating;
        private string fUrlPresentation;
        private string fUrlVideo;
        private string fReview;
        private Book fBook;
        private Speaker fSpeaker;
        private Meeting fMeeting;

        // *** Start programmer edit section *** (Presentation CustomMembers)
        // *** End programmer edit section *** (Presentation CustomMembers)

        /// <summary>
        /// Id.
        /// </summary>
        // *** Start programmer edit section *** (Speaker.FirstName CustomAttributes)
        // *** End programmer edit section *** (Speaker.FirstName CustomAttributes)
        public virtual Guid Id
        {
            get
            {
                // *** Start programmer edit section *** (Speaker.FirstName Get start)
                // *** End programmer edit section *** (Speaker.FirstName Get start)
                Guid result = this.fId;
                // *** Start programmer edit section *** (Speaker.FirstName Get end)
                // *** End programmer edit section *** (Speaker.FirstName Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Speaker.FirstName Set start)
                // *** End programmer edit section *** (Speaker.FirstName Set start)
                this.fId = value;
                // *** Start programmer edit section *** (Speaker.FirstName Set end)
                // *** End programmer edit section *** (Speaker.FirstName Set end)
            }
        }


        /// <summary>
        /// Date.
        /// </summary>
        // *** Start programmer edit section *** (Presentation.Date CustomAttributes)
        // *** End programmer edit section *** (Presentation.Date CustomAttributes)
        public virtual DateTime Date
        {
            get
            {
                // *** Start programmer edit section *** (Presentation.Date Get start)
                // *** End programmer edit section *** (Presentation.Date Get start)
                DateTime result = this.fDate;
                // *** Start programmer edit section *** (Presentation.Date Get end)
                // *** End programmer edit section *** (Presentation.Date Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Presentation.Date Set start)
                // *** End programmer edit section *** (Presentation.Date Set start)
                this.fDate = value;
                // *** Start programmer edit section *** (Presentation.Date Set end)
                // *** End programmer edit section *** (Presentation.Date Set end)
            }
        }

        /// <summary>
        /// Rating.
        /// </summary>
        // *** Start programmer edit section *** (Presentation.Rating CustomAttributes)
        // *** End programmer edit section *** (Presentation.Rating CustomAttributes)
        public virtual int Rating
        {
            get
            {
                // *** Start programmer edit section *** (Presentation.Rating Get start)
                // *** End programmer edit section *** (Presentation.Rating Get start)
                int result = this.fRating;
                // *** Start programmer edit section *** (Presentation.Rating Get end)
                // *** End programmer edit section *** (Presentation.Rating Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Presentation.Rating Set start)
                // *** End programmer edit section *** (Presentation.Rating Set start)
                this.fRating = value;
                // *** Start programmer edit section *** (Presentation.Rating Set end)
                // *** End programmer edit section *** (Presentation.Rating Set end)
            }
        }

        /// <summary>
        /// UrlPresentation.
        /// </summary>
        // *** Start programmer edit section *** (Presentation.UrlPresentation CustomAttributes)
        // *** End programmer edit section *** (Presentation.UrlPresentation CustomAttributes)
        [StrLen(255)]
        public virtual string UrlPresentation
        {
            get
            {
                // *** Start programmer edit section *** (Presentation.UrlPresentation Get start)
                // *** End programmer edit section *** (Presentation.UrlPresentation Get start)
                string result = this.fUrlPresentation;
                // *** Start programmer edit section *** (Presentation.UrlPresentation Get end)
                // *** End programmer edit section *** (Presentation.UrlPresentation Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Presentation.UrlPresentation Set start)
                // *** End programmer edit section *** (Presentation.UrlPresentation Set start)
                this.fUrlPresentation = value;
                // *** Start programmer edit section *** (Presentation.UrlPresentation Set end)
                // *** End programmer edit section *** (Presentation.UrlPresentation Set end)
            }
        }

        /// <summary>
        /// UrlVideo.
        /// </summary>
        // *** Start programmer edit section *** (Presentation.UrlVideo CustomAttributes)
        // *** End programmer edit section *** (Presentation.UrlVideo CustomAttributes)
        [StrLen(255)]
        public virtual string UrlVideo
        {
            get
            {
                // *** Start programmer edit section *** (Presentation.UrlVideo Get start)
                // *** End programmer edit section *** (Presentation.UrlVideo Get start)
                string result = this.fUrlVideo;
                // *** Start programmer edit section *** (Presentation.UrlVideo Get end)
                // *** End programmer edit section *** (Presentation.UrlVideo Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Presentation.UrlVideo Set start)
                // *** End programmer edit section *** (Presentation.UrlVideo Set start)
                this.fUrlVideo = value;
                // *** Start programmer edit section *** (Presentation.UrlVideo Set end)
                // *** End programmer edit section *** (Presentation.UrlVideo Set end)
            }
        }

        /// <summary>
        /// Review.
        /// </summary>
        // *** Start programmer edit section *** (Presentation.Review CustomAttributes)
        // *** End programmer edit section *** (Presentation.Review CustomAttributes)
        [StrLen(255)]
        public virtual string Review
        {
            get
            {
                // *** Start programmer edit section *** (Presentation.Review Get start)
                // *** End programmer edit section *** (Presentation.Review Get start)
                string result = this.fReview;
                // *** Start programmer edit section *** (Presentation.Review Get end)
                // *** End programmer edit section *** (Presentation.Review Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Presentation.Review Set start)
                // *** End programmer edit section *** (Presentation.Review Set start)
                this.fReview = value;
                // *** Start programmer edit section *** (Presentation.Review Set end)
                // *** End programmer edit section *** (Presentation.Review Set end)
            }
        }

        /// <summary>
        /// Presentation.
        /// </summary>
        // *** Start programmer edit section *** (Presentation.Book CustomAttributes)
        // *** End programmer edit section *** (Presentation.Book CustomAttributes)
        [NotNull()]
        public virtual Book Book
        {
            get
            {
                // *** Start programmer edit section *** (Presentation.Book Get start)
                // *** End programmer edit section *** (Presentation.Book Get start)
                Book result = this.fBook;
                // *** Start programmer edit section *** (Presentation.Book Get end)
                // *** End programmer edit section *** (Presentation.Book Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Presentation.Book Set start)
                // *** End programmer edit section *** (Presentation.Book Set start)
                this.fBook = value;
                // *** Start programmer edit section *** (Presentation.Book Set end)
                // *** End programmer edit section *** (Presentation.Book Set end)
            }
        }

        /// <summary>
        /// Presentation.
        /// </summary>
        // *** Start programmer edit section *** (Presentation.Speaker CustomAttributes)
        // *** End programmer edit section *** (Presentation.Speaker CustomAttributes)
        [NotNull()]
        public virtual Speaker Speaker
        {
            get
            {
                // *** Start programmer edit section *** (Presentation.Speaker Get start)
                // *** End programmer edit section *** (Presentation.Speaker Get start)
                Speaker result = this.fSpeaker;
                // *** Start programmer edit section *** (Presentation.Speaker Get end)
                // *** End programmer edit section *** (Presentation.Speaker Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Presentation.Speaker Set start)
                // *** End programmer edit section *** (Presentation.Speaker Set start)
                this.fSpeaker = value;
                // *** Start programmer edit section *** (Presentation.Speaker Set end)
                // *** End programmer edit section *** (Presentation.Speaker Set end)
            }
        }

        /// <summary>
        /// мастеровая ссылка на шапку IIS.Product_34447.Meeting.
        /// </summary>
        // *** Start programmer edit section *** (Presentation.Meeting CustomAttributes)
        // *** End programmer edit section *** (Presentation.Meeting CustomAttributes)
        [Agregator()]
        [NotNull()]
        public virtual Meeting Meeting
        {
            get
            {
                // *** Start programmer edit section *** (Presentation.Meeting Get start)
                // *** End programmer edit section *** (Presentation.Meeting Get start)
                Meeting result = this.fMeeting;
                // *** Start programmer edit section *** (Presentation.Meeting Get end)
                // *** End programmer edit section *** (Presentation.Meeting Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Presentation.Meeting Set start)
                // *** End programmer edit section *** (Presentation.Meeting Set start)
                this.fMeeting = value;
                // *** Start programmer edit section *** (Presentation.Meeting Set end)
                // *** End programmer edit section *** (Presentation.Meeting Set end)
            }
        }

        /// <summary>
        /// Class views container.
        /// </summary>
        public class Views
        {

            /// <summary>
            /// "PresentationE" view.
            /// </summary>
            public static View PresentationE
            {
                get
                {
                    return Information.GetView("PresentationE", typeof(Presentation));
                }
            }
        }
    }

    /// <summary>
    /// Detail array of Presentation.
    /// </summary>
    // *** Start programmer edit section *** (DetailArrayDetailArrayOfPresentation CustomAttributes)
    // *** End programmer edit section *** (DetailArrayDetailArrayOfPresentation CustomAttributes)
    public class DetailArrayOfPresentation : DetailArray
    {

        // *** Start programmer edit section *** (IIS.Product_34447.DetailArrayOfPresentation members)
        // *** End programmer edit section *** (IIS.Product_34447.DetailArrayOfPresentation members)


        /// <summary>
        /// Construct detail array.
        /// </summary>
        /// <summary>
        /// Returns object with type Presentation by index.
        /// </summary>
        /// <summary>
        /// Adds object with type Presentation.
        /// </summary>
        public DetailArrayOfPresentation(Meeting fMeeting) :
                base(typeof(Presentation), ((DataObject)(fMeeting)))
        {
        }

        public Presentation this[int index]
        {
            get
            {
                return ((Presentation)(this.ItemByIndex(index)));
            }
        }

        public virtual void Add(Presentation dataobject)
        {
            this.AddObject(((DataObject)(dataobject)));
        }
    }

}
