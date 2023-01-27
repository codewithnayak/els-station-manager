using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StationManagerApi.Db
{
    public class Station : IValidatableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StationCode { get; set; }
        public Address Address { get; set; }
        public string StateCode { get; set; }
        public Guid StationIdentifier { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var stateCodeLength = 4;
           if(StateCode.Length > stateCodeLength) yield return new ValidationResult($"State code can not be more than {stateCodeLength}");
        }
    }


    public class Address
    {
        public int Id { get; set; }
        public int BuilidingNumber { get; set; }
        public string BuildingName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public int Pin { get; set; }
        public Station Station { get; set; }

        public int StationId { get; set; }
    }

}
