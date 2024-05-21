using Newtonsoft.Json;
using TechIntegration.Core.Models;

namespace TechIntegration.Infra.Requests;

public class FieldRequest
{
    [JsonProperty("customFieldItems")] public List<CustomFieldItem> CustomFieldItems { get; set; } = new();

    public static FieldRequest CreatFieldRequestFromFields(List<Field> fields, Tender tender)
    {
        var customFieldItems = new List<CustomFieldItem>();

        foreach (var field in fields)
        {
            var customFieldItem = new CustomFieldItem
            {
                IdCustomField = field.Id,
                Value = new Value()
            };

            switch (field.Name)
            {
                case "Id":
                {
                    customFieldItem.Value = new TextValue()
                    {
                        Text = tender.Id.ToString(),
                    };
                    customFieldItems.Add(customFieldItem);

                    break;
                }
                case "TenderId":
                {
                    customFieldItem.Value = new TextValue()
                    {
                        Text = tender.TenderId.ToString(),
                    };
                    customFieldItems.Add(customFieldItem);

                    break;
                }
                case "LotNumber":
                {
                    customFieldItem.Value = new TextValue
                    {
                        Text = tender.LotNumber ?? "",
                    };
                    customFieldItems.Add(customFieldItem);

                    break;
                }
                case "Deadline":
                {
                    if (tender.Deadline.HasValue)
                    {
                        customFieldItem.Value = new DateValue { Date = tender.Deadline.Value, };
                    }

                    customFieldItems.Add(customFieldItem);

                    break;
                }
                case "Name":
                {
                    customFieldItem.Value = new TextValue
                    {
                        Text = tender.Name ?? "",
                    };
                    customFieldItems.Add(customFieldItem);

                    break;
                }
                case "TenderName":
                {
                    customFieldItem.Value = new TextValue
                    {
                        Text = tender.TenderName ?? "",
                    };
                    customFieldItems.Add(customFieldItem);

                    break;
                }
                case "ExpirationDate":
                {
                    if (tender.ExpirationDate == null)
                    {
                        break;
                    }

                    customFieldItem.Value = new DateValue { Date = tender.ExpirationDate ?? DateTime.MinValue };
                    customFieldItems.Add(customFieldItem);

                    break;
                }

                case "HasDocuments":
                {
                    customFieldItem.Value = new CheckedValue { IsChecked = tender.HasDocuments };
                    customFieldItems.Add(customFieldItem);

                    break;
                }
                case "Location":
                {
                    customFieldItem.Value = new TextValue
                    {
                        Text = tender.Location ?? "",
                    };
                    customFieldItems.Add(customFieldItem);
                    break;
                }
                case "PublicationDate":
                {
                    if (tender.PublicationDate == null)
                    {
                        break;
                    }

                    DateTimeOffset dateTimeOffset = DateTimeOffset.Parse(tender.PublicationDate);


                    customFieldItem.Value = new DateValue { Date = dateTimeOffset.UtcDateTime.Date };
                    customFieldItems.Add(customFieldItem);

                    break;
                }
      
                case "Currency":
                {
                    customFieldItem.Value = new TextValue
                    {
                        Text = tender.Currency ?? "N/A",
                    };
                    customFieldItems.Add(customFieldItem);

                    break;
                }
                case "Status":
                {
                    customFieldItem.Value = new TextValue
                    {
                        Text = StatusDictionary.Dictionary[tender.Status],
                    };
                    customFieldItems.Add(customFieldItem);

                    break;
                }
                case "Value":
                {
                    customFieldItem.Value = new TextValue()
                    {
                        Text = tender.Value ?? "0",
                    };
                    customFieldItems.Add(customFieldItem);

                    break;
                }
                default:
                    continue;
            }
        }

        return new FieldRequest
        {
            CustomFieldItems = customFieldItems
        };
    }
}