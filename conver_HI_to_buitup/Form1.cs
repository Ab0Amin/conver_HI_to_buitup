using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tekla.Structures.Model;
using T3D =Tekla.Structures.Geometry3d;
using Tekla.Structures.Geometry3d;

using Tekla.Structures.Model.UI;

namespace conver_HI_to_buitup
{
    public partial class Form1 : Form
    {
        Model model = new Model();

        public Beam create_plate(string Plate_width, string Plate_thik, string Plate_matrial, T3D.Point Plate_start_point, T3D.Point Plate_end_point)
        {
            Beam plate = new Beam();

           plate.Profile.ProfileString = "PL" + Plate_width + "*" + Plate_thik;
            plate.Material.MaterialString = Plate_matrial;
            plate.Position.Rotation = Position.RotationEnum.TOP;
            plate.Position.Depth = Position.DepthEnum.MIDDLE;
            plate.Position.Plane = Position.PlaneEnum.MIDDLE;
            plate.StartPoint = Plate_start_point;
            plate.EndPoint = Plate_end_point;
            plate.PartNumber.StartNumber = 101;
            plate.PartNumber.Prefix = "W";
            plate.AssemblyNumber.Prefix = "";
            plate.AssemblyNumber.StartNumber = 9001;
            plate.Name = "PLATE";

            plate.Insert();
            return plate;

        }
        public Beam create_plate(string Plate_width, string Plate_thik, string Plate_matrial, T3D.Point Plate_start_point, T3D.Point Plate_end_point , Position.RotationEnum rotationEnum )
        {
            Beam plate = new Beam();

            plate.Profile.ProfileString = "PL" + Plate_width + "*" + Plate_thik;
            plate.Material.MaterialString = Plate_matrial;
            plate.Position.Rotation =  rotationEnum ;
            plate.Position.Depth = Position.DepthEnum.MIDDLE;
            plate.Position.Plane = Position.PlaneEnum.MIDDLE;
            plate.StartPoint = Plate_start_point;
            plate.EndPoint = Plate_end_point;
            plate.PartNumber.StartNumber = 101;
            plate.PartNumber.Prefix = "W";
            plate.AssemblyNumber.Prefix = "";
            plate.AssemblyNumber.StartNumber = 9001;
            plate.Name = "PLATE";
            plate.Insert();
            return plate;

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button_convert_Click(object sender, EventArgs e)
        {
            try
            {
                // piccker

                Picker picker_HI = new Picker();
                Beam converted_part = picker_HI.PickObject(Picker.PickObjectEnum.PICK_ONE_PART) as Beam;

                // parametr
                Double beam_length = 0;
                Double beam_web_height = 0;
                Double beam_web_thik = 0;
                Double beam_flg_width = 0;
                Double beam_flg_thik = 0;
                string beam_matrial = null;

                //change coordinates
                model.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TransformationPlane(converted_part.GetCoordinateSystem()));
                // get picked beam proprties
                converted_part.GetReportProperty("LENGTH", ref beam_length);
                converted_part.GetReportProperty("WEB_HEIGHT", ref beam_web_height);
                converted_part.GetReportProperty("PROFILE.WEB_THICKNESS", ref beam_web_thik);
                converted_part.GetReportProperty("WIDTH", ref beam_flg_width);
                converted_part.GetReportProperty("PROFILE.FLANGE_THICKNESS", ref beam_flg_thik);
                converted_part.GetReportProperty("MATERIAL", ref beam_matrial);


                Solid solid_converted_bean = converted_part.GetSolid();
                T3D.Point maxpoint = solid_converted_bean.MaximumPoint;
                T3D.Point minpoint = solid_converted_bean.MinimumPoint;
                // top plate points
                T3D.Point top_plate_start_point = new T3D.Point(0, maxpoint.Y - beam_flg_thik / 2, 0);
                T3D.Point top_plate_end_point = new T3D.Point(beam_length, maxpoint.Y - beam_flg_thik / 2, 0);

                //bottom pate points
                T3D.Point bottom_plate_start_point = new T3D.Point(0, minpoint.Y + beam_flg_thik / 2, 0);
                T3D.Point bottom_plate_end_point = new T3D.Point(beam_length, minpoint.Y + beam_flg_thik / 2, 0);


                //web plate points
                T3D.Point web_plate_start_point = new T3D.Point(0, 0, 0);
                T3D.Point web_plate_end_point = new T3D.Point(beam_length, 0, 0);





                //plate insert
                create_plate(beam_flg_width.ToString(), beam_flg_thik.ToString(), beam_matrial, top_plate_start_point, top_plate_end_point);
                create_plate(beam_flg_width.ToString(), beam_flg_thik.ToString(), beam_matrial, bottom_plate_start_point, bottom_plate_end_point);
                create_plate(beam_web_height.ToString(), beam_web_thik.ToString(), beam_matrial, web_plate_start_point, web_plate_end_point, Position.RotationEnum.FRONT);

                //set coordinates to global
                model.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TransformationPlane());
                // delete l beam
                if (checkBox_delete_converted_beam.Checked == true)
                {
                    converted_part.Delete();
                }
              
                model.CommitChanges();

            }
            catch (Exception)
            {

                throw;
            } 
           
            
        }

        private void checkBox_delete_converted_beam_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
