using ICSSoft.STORMNET;
using System;

namespace BookClub.Domains
{
    // *** Start programmer edit section *** (Using statements)
    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// Speaker.
    /// </summary>
    // *** Start programmer edit section *** (Speaker CustomAttributes)
    // *** End programmer edit section *** (Speaker CustomAttributes)
    [PrimaryKeyStorage("Id")]
    [AutoAltered()]
    [AccessType(AccessType.none)]
    [View("SpeakerE", new string[] {
            "FirstName as \'First name\'",
            "LastName as \'Last name\'",
            "MiddleName as \'Middle name\'",
            "Foto as \'Foto\'"})]
    [View("SpeakerL", new string[] {
            "Id as \'Id\'",
            "FirstName as \'First name\'",
            "LastName as \'Last name\'",
            "MiddleName as \'Middle name\'",
            "Foto as \'Foto\'"})]
    public class Speaker : DataObject
    {
        private Guid fId;
        private string fFirstName;
        private string fLastName;
        private string fMiddleName;
        private string fFoto;
        // *** Start programmer edit section *** (Speaker CustomMembers)
        // *** End programmer edit section *** (Speaker CustomMembers)


        /// <summary>
        /// FirstName.
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
        /// FirstName.
        /// </summary>
        // *** Start programmer edit section *** (Speaker.FirstName CustomAttributes)

        // *** End programmer edit section *** (Speaker.FirstName CustomAttributes)
        [StrLen(255)]
        public virtual string FirstName
        {
            get
            {
                // *** Start programmer edit section *** (Speaker.FirstName Get start)

                // *** End programmer edit section *** (Speaker.FirstName Get start)
                string result = this.fFirstName;
                // *** Start programmer edit section *** (Speaker.FirstName Get end)

                // *** End programmer edit section *** (Speaker.FirstName Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Speaker.FirstName Set start)

                // *** End programmer edit section *** (Speaker.FirstName Set start)
                this.fFirstName = value;
                // *** Start programmer edit section *** (Speaker.FirstName Set end)

                // *** End programmer edit section *** (Speaker.FirstName Set end)
            }
        }

        /// <summary>
        /// LastName.
        /// </summary>
        // *** Start programmer edit section *** (Speaker.LastName CustomAttributes)

        // *** End programmer edit section *** (Speaker.LastName CustomAttributes)
        [StrLen(255)]
        public virtual string LastName
        {
            get
            {
                // *** Start programmer edit section *** (Speaker.LastName Get start)

                // *** End programmer edit section *** (Speaker.LastName Get start)
                string result = this.fLastName;
                // *** Start programmer edit section *** (Speaker.LastName Get end)

                // *** End programmer edit section *** (Speaker.LastName Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Speaker.LastName Set start)

                // *** End programmer edit section *** (Speaker.LastName Set start)
                this.fLastName = value;
                // *** Start programmer edit section *** (Speaker.LastName Set end)

                // *** End programmer edit section *** (Speaker.LastName Set end)
            }
        }

        /// <summary>
        /// MiddleName.
        /// </summary>
        // *** Start programmer edit section *** (Speaker.MiddleName CustomAttributes)

        // *** End programmer edit section *** (Speaker.MiddleName CustomAttributes)
        [StrLen(255)]
        public virtual string MiddleName
        {
            get
            {
                // *** Start programmer edit section *** (Speaker.MiddleName Get start)

                // *** End programmer edit section *** (Speaker.MiddleName Get start)
                string result = this.fMiddleName;
                // *** Start programmer edit section *** (Speaker.MiddleName Get end)

                // *** End programmer edit section *** (Speaker.MiddleName Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Speaker.MiddleName Set start)

                // *** End programmer edit section *** (Speaker.MiddleName Set start)
                this.fMiddleName = value;
                // *** Start programmer edit section *** (Speaker.MiddleName Set end)

                // *** End programmer edit section *** (Speaker.MiddleName Set end)
            }
        }

        /// <summary>
        /// Foto.
        /// </summary>
        // *** Start programmer edit section *** (Speaker.Foto CustomAttributes)

        // *** End programmer edit section *** (Speaker.Foto CustomAttributes)
        [StrLen(255)]
        public virtual string Foto
        {
            get
            {
                // *** Start programmer edit section *** (Speaker.Foto Get start)

                // *** End programmer edit section *** (Speaker.Foto Get start)
                string result = this.fFoto;
                // *** Start programmer edit section *** (Speaker.Foto Get end)

                // *** End programmer edit section *** (Speaker.Foto Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Speaker.Foto Set start)

                // *** End programmer edit section *** (Speaker.Foto Set start)
                this.fFoto = value;
                // *** Start programmer edit section *** (Speaker.Foto Set end)

                // *** End programmer edit section *** (Speaker.Foto Set end)
            }
        }

        /// <summary>
        /// Class views container.
        /// </summary>
        public class Views
        {

            /// <summary>
            /// "SpeakerE" view.
            /// </summary>
            public static View SpeakerE
            {
                get
                {
                    return Information.GetView("SpeakerE", typeof(Speaker));
                }
            }

            /// <summary>
            /// "SpeakerL" view.
            /// </summary>
            public static View SpeakerL
            {
                get
                {
                    return Information.GetView("SpeakerL", typeof(Speaker));
                }
            }
        }
    }
}
