
using FintechCase.Utility;
using FintechPaintTestCase.Models;
using System.Text.Json.Nodes;

namespace FintechCase
{
    internal class FileOperations
    {
        public void saveShapes(List<Shape> shapes)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Dosyaları (*.json)|*.json|Tüm Dosyalar (*.*)|*.*";
            saveFileDialog.Title = "JSON Dosyası Kaydet";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                JsonArray shapesJSON = new JsonArray();
                foreach (var shape in shapes)
                {
                    shapesJSON.Add(shape.getJSONInfos());
                }
                string filePath = saveFileDialog.FileName;
                File.WriteAllText(filePath, shapesJSON.ToString());
                MessageBox.Show("Dosya başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public List<Shape> loadShapes()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Dosyaları (*.json)|*.json|Tüm Dosyalar (*.*)|*.*";
            openFileDialog.Title = "JSON Dosyası Aç";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string jsonString = File.ReadAllText(filePath);
                JsonArray jsonArray = JsonNode.Parse(jsonString).AsArray();
                List<Shape> shapes = new List<Shape>();
                foreach (JsonNode jsonNode in jsonArray)
                {
                    JsonObject jsonObject = jsonNode.AsObject();

                    Shape shape;
                    switch (jsonObject["Name"].GetValue<string>())
                    {
                        case "circle":
                            shape = new Circle
                                (ColorTools.findColorByName(jsonObject["Color"].GetValue<string>()),
                                jsonObject["X"].GetValue<int>(),
                                jsonObject["Y"].GetValue<int>(),
                                jsonObject["Height"].GetValue<int>(),
                                jsonObject["Width"].GetValue<int>(),
                            jsonObject["isSelected"].GetValue<bool>()

                                );
                            break;
                        case "hexagon":
                            shape = new Hexagon
                            (ColorTools.findColorByName(jsonObject["Color"].GetValue<string>()),
                            jsonObject["X"].GetValue<int>(),
                            jsonObject["Y"].GetValue<int>(),
                            jsonObject["Height"].GetValue<int>(),
                            jsonObject["Width"].GetValue<int>(),
                            jsonObject["isSelected"].GetValue<bool>()
                            );
                            break;
                        case "triangle":
                            shape = new Triangle
          (ColorTools.findColorByName(jsonObject["Color"].GetValue<string>()),
          jsonObject["X"].GetValue<int>(),
          jsonObject["Y"].GetValue<int>(),
          jsonObject["Height"].GetValue<int>(),
          jsonObject["Width"].GetValue<int>(),
                            jsonObject["isSelected"].GetValue<bool>()

          );
                            break;
                        case "square":
                            shape = new Square
    (ColorTools.findColorByName(jsonObject["Color"].GetValue<string>()),
    jsonObject["X"].GetValue<int>(),
    jsonObject["Y"].GetValue<int>(),
    jsonObject["Height"].GetValue<int>(),
    jsonObject["Width"].GetValue<int>(),
                            jsonObject["isSelected"].GetValue<bool>()

    );
                            break;

                        default:
                            return null;
                            break;
                    }
                    shapes.Add(shape);


                }
                return shapes;
            }
            return null;           
        }
    }
}
