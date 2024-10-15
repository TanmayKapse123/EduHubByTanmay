using EduHubMVC.Models;
using EduHubMVC.ViewModel;

namespace EduHubMVC.Services;
public interface IMaterialService
{
// Material GetMaterial(int materialId);
IEnumerable<Material> GetAllMaterials ();
public List<Material> GetMaterialByCourseId(int courseId); 
 void CreateMaterial (Material newMaterial);
 void UpdateMaterial (int materialid, Material updatedMaterial);
 bool DeleteMaterial (int materialId);
 public int GetuserId(int cid);
 }

