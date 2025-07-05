using DiffCode.Validating.Abstractions;
using DiffCode.Validating.Interfaces;

namespace DiffCode.Validating.Models;


public class ElementValidator : BaseElementValidator<TestValidatableElement>
{
  public ElementValidator() : base()
  {
     
  }


}





public class TestValidatableElement : IValidatable<TestValidatableElement>
{


  public int Amount { get; set; }


  public string Name { get; set; } = "";


  public List<string> Tags { get; set; } = [];


}
