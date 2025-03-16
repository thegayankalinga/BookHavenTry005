using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Enumz
{
    using System.Runtime.Serialization;

    public enum BookGenres
    {
        [EnumMember(Value = "Fiction")]
        Fiction = 0,

        [EnumMember(Value = "Non-Fiction")]
        NonFiction = 1,

        [EnumMember(Value = "Mystery")]
        Mystery = 2,

        [EnumMember(Value = "Science Fiction")]
        ScienceFiction = 3,

        [EnumMember(Value = "Fantasy")]
        Fantasy = 4,

        [EnumMember(Value = "Romance")]
        Romance = 5,

        [EnumMember(Value = "Thriller")]
        Thriller = 6,

        [EnumMember(Value = "Historical Fiction")]
        HistoricalFiction = 7,

        [EnumMember(Value = "Biography")]
        Biography = 8,

        [EnumMember(Value = "Autobiography")]
        Autobiography = 9,

        [EnumMember(Value = "Self-Help")]
        SelfHelp = 10,

        [EnumMember(Value = "Poetry")]
        Poetry = 11,

        [EnumMember(Value = "Children's Literature")]
        ChildrensLiterature = 12,

        [EnumMember(Value = "Young Adult")]
        YoungAdult = 13,

        [EnumMember(Value = "Horror")]
        Horror = 14,

        [EnumMember(Value = "Cookbook")]
        Cookbook = 15,

        [EnumMember(Value = "Travel")]
        Travel = 16,

        [EnumMember(Value = "Business")]
        Business = 17,

        [EnumMember(Value = "Technology")]
        Technology = 18,

        [EnumMember(Value = "Religion")]
        Religion = 19,

        [EnumMember(Value = "Philosophy")]
        Philosophy = 20,

        [EnumMember(Value = "Comics")]
        Comics = 21,

        [EnumMember(Value = "Graphic Novel")]
        GraphicNovel = 22,

        [EnumMember(Value = "Drama")]
        Drama = 23,

        [EnumMember(Value = "Crime")]
        Crime = 24,

        [EnumMember(Value = "Essay")]
        Essay = 25,

        [EnumMember(Value = "Textbook")]
        Textbook = 26,

        [EnumMember(Value = "Reference")]
        Reference = 27,

        [EnumMember(Value = "True Crime")]
        TrueCrime = 28,

        [EnumMember(Value = "Science")]
        Science = 29,

        [EnumMember(Value = "History")]
        History = 30,

        [EnumMember(Value = "Art")]
        Art = 31,

        [EnumMember(Value = "Health")]
        Health = 32,

        [EnumMember(Value = "Sports")]
        Sports = 33,

        [EnumMember(Value = "Education")]
        Education = 34,

        [EnumMember(Value = "Crafts")]
        Crafts = 35
    }

}
