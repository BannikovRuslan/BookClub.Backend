using ICSSoft.STORMNET;
using System;

namespace BookClub.Domains
{

    [PrimaryKeyStorage("Id")]
    [AutoAltered()]
    [AccessType(AccessType.none)]
    [View("BookE", new string[] {
        "Title as \'Title\'",
        "Author as \'Author\'",
        "Pages as \'Pages\'",
        "Cover as \'Cover\'",
        "Tags as \'Tags\'",
        "Description as \'Description\'",
        "Rating as \'Rating\'"})]
    [View("BookL", new string[] {
        "Id as \'Id\'",
        "Title as \'Title\'",
        "Author as \'Author\'",
        "Pages as \'Pages\'",
        "Cover as \'Cover\'",
        "Tags as \'Tags\'",
        "Description as \'Description\'",
        "Rating as \'Rating\'"})]
    public class Book : DataObject
    {
        private Guid fId;
        private string fTitle;
        private string fAuthor;
        private int fPages;
        private string fCover;
        private string fTags;
        private string fDescription;
        private double fRating;

        // *** Start programmer edit section *** (Book CustomMembers)
        // *** End programmer edit section *** (Book CustomMembers)

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
        /// Title.
        /// </summary>
        // *** Start programmer edit section *** (Book.Title CustomAttributes)

        // *** End programmer edit section *** (Book.Title CustomAttributes)
        [StrLen(255)]
        public virtual string Title
        {
            get
            {
                // *** Start programmer edit section *** (Book.Title Get start)

                // *** End programmer edit section *** (Book.Title Get start)
                string result = this.fTitle;
                // *** Start programmer edit section *** (Book.Title Get end)

                // *** End programmer edit section *** (Book.Title Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Book.Title Set start)

                // *** End programmer edit section *** (Book.Title Set start)
                this.fTitle = value;
                // *** Start programmer edit section *** (Book.Title Set end)

                // *** End programmer edit section *** (Book.Title Set end)
            }
        }

        /// <summary>
        /// Author.
        /// </summary>
        // *** Start programmer edit section *** (Book.Author CustomAttributes)

        // *** End programmer edit section *** (Book.Author CustomAttributes)
        [StrLen(255)]
        public virtual string Author
        {
            get
            {
                // *** Start programmer edit section *** (Book.Author Get start)

                // *** End programmer edit section *** (Book.Author Get start)
                string result = this.fAuthor;
                // *** Start programmer edit section *** (Book.Author Get end)

                // *** End programmer edit section *** (Book.Author Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Book.Author Set start)

                // *** End programmer edit section *** (Book.Author Set start)
                this.fAuthor = value;
                // *** Start programmer edit section *** (Book.Author Set end)

                // *** End programmer edit section *** (Book.Author Set end)
            }
        }

        /// <summary>
        /// Pages.
        /// </summary>
        // *** Start programmer edit section *** (Book.Pages CustomAttributes)

        // *** End programmer edit section *** (Book.Pages CustomAttributes)
        public virtual int Pages
        {
            get
            {
                // *** Start programmer edit section *** (Book.Pages Get start)

                // *** End programmer edit section *** (Book.Pages Get start)
                int result = this.fPages;
                // *** Start programmer edit section *** (Book.Pages Get end)

                // *** End programmer edit section *** (Book.Pages Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Book.Pages Set start)

                // *** End programmer edit section *** (Book.Pages Set start)
                this.fPages = value;
                // *** Start programmer edit section *** (Book.Pages Set end)

                // *** End programmer edit section *** (Book.Pages Set end)
            }
        }

        /// <summary>
        /// Cover.
        /// </summary>
        // *** Start programmer edit section *** (Book.Cover CustomAttributes)

        // *** End programmer edit section *** (Book.Cover CustomAttributes)
        [StrLen(255)]
        public virtual string Cover
        {
            get
            {
                // *** Start programmer edit section *** (Book.Cover Get start)

                // *** End programmer edit section *** (Book.Cover Get start)
                string result = this.fCover;
                // *** Start programmer edit section *** (Book.Cover Get end)

                // *** End programmer edit section *** (Book.Cover Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Book.Cover Set start)

                // *** End programmer edit section *** (Book.Cover Set start)
                this.fCover = value;
                // *** Start programmer edit section *** (Book.Cover Set end)

                // *** End programmer edit section *** (Book.Cover Set end)
            }
        }

        /// <summary>
        /// Tags.
        /// </summary>
        // *** Start programmer edit section *** (Book.Tags CustomAttributes)

        // *** End programmer edit section *** (Book.Tags CustomAttributes)
        [StrLen(255)]
        public virtual string Tags
        {
            get
            {
                // *** Start programmer edit section *** (Book.Tags Get start)

                // *** End programmer edit section *** (Book.Tags Get start)
                string result = this.fTags;
                // *** Start programmer edit section *** (Book.Tags Get end)

                // *** End programmer edit section *** (Book.Tags Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Book.Tags Set start)

                // *** End programmer edit section *** (Book.Tags Set start)
                this.fTags = value;
                // *** Start programmer edit section *** (Book.Tags Set end)

                // *** End programmer edit section *** (Book.Tags Set end)
            }
        }

        /// <summary>
        /// Description.
        /// </summary>
        // *** Start programmer edit section *** (Book.Description CustomAttributes)

        // *** End programmer edit section *** (Book.Description CustomAttributes)
        [StrLen(255)]
        public virtual string Description
        {
            get
            {
                // *** Start programmer edit section *** (Book.Description Get start)

                // *** End programmer edit section *** (Book.Description Get start)
                string result = this.fDescription;
                // *** Start programmer edit section *** (Book.Description Get end)

                // *** End programmer edit section *** (Book.Description Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Book.Description Set start)

                // *** End programmer edit section *** (Book.Description Set start)
                this.fDescription = value;
                // *** Start programmer edit section *** (Book.Description Set end)

                // *** End programmer edit section *** (Book.Description Set end)
            }
        }

        /// <summary>
        /// Rating.
        /// </summary>
        // *** Start programmer edit section *** (Book.Rating CustomAttributes)

        // *** End programmer edit section *** (Book.Rating CustomAttributes)
        public virtual double Rating
        {
            get
            {
                // *** Start programmer edit section *** (Book.Rating Get start)

                // *** End programmer edit section *** (Book.Rating Get start)
                double result = this.fRating;
                // *** Start programmer edit section *** (Book.Rating Get end)

                // *** End programmer edit section *** (Book.Rating Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Book.Rating Set start)

                // *** End programmer edit section *** (Book.Rating Set start)
                this.fRating = value;
                // *** Start programmer edit section *** (Book.Rating Set end)

                // *** End programmer edit section *** (Book.Rating Set end)
            }
        }

        /// <summary>
        /// Class views container.
        /// </summary>
        public class Views
        {

            /// <summary>
            /// "BookE" view.
            /// </summary>
            public static View BookE
            {
                get
                {
                    return Information.GetView("BookE", typeof(Book));
                }
            }

            /// <summary>
            /// "BookL" view.
            /// </summary>
            public static View BookL
            {
                get
                {
                    return Information.GetView("BookL", typeof(Book));
                }
            }
        }
    }

}
