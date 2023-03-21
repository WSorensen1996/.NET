﻿using System.ComponentModel.DataAnnotations;

namespace taskhero.Models.DTOs
{
    public class userInformationDTO
    {

        public int Id { get; set; }

        [Required]

        public string birthday { get; set; }
        public string catchprase { get; set; }

        public string description { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public string imageURL { get; set; }

        public bool TermsAndConditionsAccepted { get; set; }

    }
}
