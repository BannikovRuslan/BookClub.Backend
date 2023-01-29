using ICSSoft.STORMNET;
using System;

namespace BookClub.Domains
{
    /// <summary>
    /// Meeting.
    /// </summary>
    // *** Start programmer edit section *** (Meeting CustomAttributes)

    // *** End programmer edit section *** (Meeting CustomAttributes)
    [PrimaryKeyStorage("Id")]
    [AutoAltered()]
    [AccessType(AccessType.none)]
    [View("MeetingE", new string[] {
            "Date as \'Date\'"})]
    [AssociatedDetailViewAttribute("MeetingE", "Presentation", "PresentationE", true, "", "Presentation", true, new string[] { "" })]
    [View("MeetingL", new string[] {
            "Id as \'Id\'",
            "Date as \'Date\'"})]
    [AssociatedDetailViewAttribute("MeetingL", "Presentation", "PresentationE", true, "", "Presentation", true, new string[] { "" })]
    public class Meeting : DataObject
    {
        private Guid fId;
        private DateTime fDate;
        private DetailArrayOfPresentation fPresentation;

        // *** Start programmer edit section *** (Meeting CustomMembers)
        // *** End programmer edit section *** (Meeting CustomMembers)

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
        // *** Start programmer edit section *** (Meeting.Date CustomAttributes)
        // *** End programmer edit section *** (Meeting.Date CustomAttributes)
        public virtual DateTime Date
        {
            get
            {
                // *** Start programmer edit section *** (Meeting.Date Get start)
                // *** End programmer edit section *** (Meeting.Date Get start)
                DateTime result = this.fDate;
                // *** Start programmer edit section *** (Meeting.Date Get end)
                // *** End programmer edit section *** (Meeting.Date Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Meeting.Date Set start)
                // *** End programmer edit section *** (Meeting.Date Set start)
                this.fDate = value;
                // *** Start programmer edit section *** (Meeting.Date Set end)
                // *** End programmer edit section *** (Meeting.Date Set end)
            }
        }

        /// <summary>
        /// Meeting.
        /// </summary>
        // *** Start programmer edit section *** (Meeting.Presentation CustomAttributes)
        // *** End programmer edit section *** (Meeting.Presentation CustomAttributes)
        public virtual DetailArrayOfPresentation Presentation
        {
            get
            {
                // *** Start programmer edit section *** (Meeting.Presentation Get start)
                // *** End programmer edit section *** (Meeting.Presentation Get start)
                if ((this.fPresentation == null))
                {
                    this.fPresentation = new DetailArrayOfPresentation(this);
                }
                DetailArrayOfPresentation result = this.fPresentation;
                // *** Start programmer edit section *** (Meeting.Presentation Get end)
                // *** End programmer edit section *** (Meeting.Presentation Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Meeting.Presentation Set start)
                // *** End programmer edit section *** (Meeting.Presentation Set start)
                this.fPresentation = value;
                // *** Start programmer edit section *** (Meeting.Presentation Set end)
                // *** End programmer edit section *** (Meeting.Presentation Set end)
            }
        }

        /// <summary>
        /// Class views container.
        /// </summary>
        public class Views
        {

            /// <summary>
            /// "MeetingE" view.
            /// </summary>
            public static View MeetingE
            {
                get
                {
                    return Information.GetView("MeetingE", typeof(Meeting));
                }
            }

            /// <summary>
            /// "MeetingL" view.
            /// </summary>
            public static View MeetingL
            {
                get
                {
                    return Information.GetView("MeetingL", typeof(Meeting));
                }
            }
        }
    }

}
