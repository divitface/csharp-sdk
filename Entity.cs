using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivitfaceSDK.Models
{
    public class Face
    {


        public string Id { get; set; }

        public string image_id { get; set; }

        public string person_id { get; set; }
        public string facePath { get; set; }
        public string Gender { get; set; }

        public long Age { get; set; }

        public AnalysisResult analysisResult { get; set; }

        public string vectorList_lzm { get; set; }

        public string vectorList_lzm_bb_m1 { get; set; }


        public Face()
        {
            // TODO: Complete member initialization
        }


    }


    public class AnalysisResult
    {

        string Id { get; set; }
        public int facedata_width { get; set; }
        public int facedata_height { get; set; }
        public int facedata_channel { get; set; }

        public int detectedFace_x1 { get; set; }
        public int detectedFace_y1 { get; set; }
        public int detectedFace_x2 { get; set; }
        public int detectedFace_y2 { get; set; }
        public int detectedFace_width { get; set; }
        public int detectedFace_height { get; set; }

        public int extendedFaceAbsolute_x1 { get; set; }
        public int extendedFaceAbsolute_y1 { get; set; }
        public int extendedFaceAbsolute_x2 { get; set; }
        public int extendedFaceAbsolute_y2 { get; set; }
        public int extendedFaceAbsolute_width { get; set; }
        public int extendedFaceAbsolute_height { get; set; }

        public int face_x1 { get; set; }
        public int face_y1 { get; set; }
        public int face_x2 { get; set; }
        public int face_y2 { get; set; }
        public int face_width { get; set; }
        public int face_height { get; set; }

        public int leftEye_x1 { get; set; }
        public int leftEye_y1 { get; set; }
        public int leftEye_x2 { get; set; }
        public int leftEye_y2 { get; set; }
        public int leftEye_width { get; set; }
        public int leftEye_height { get; set; }

        public int mouth_x1 { get; set; }
        public int mouth_y1 { get; set; }
        public int mouth_x2 { get; set; }
        public int mouth_y2 { get; set; }
        public int mouth_width { get; set; }
        public int mouth_height { get; set; }

        public int noseBridge_x1 { get; set; }
        public int noseBridge_y1 { get; set; }
        public int noseBridge_x2 { get; set; }
        public int noseBridge_y2 { get; set; }
        public int noseBridge_width { get; set; }
        public int noseBridge_height { get; set; }

        public int rightEye_x1 { get; set; }
        public int rightEye_y1 { get; set; }
        public int rightEye_x2 { get; set; }
        public int rightEye_y2 { get; set; }
        public int rightEye_width { get; set; }
        public int rightEye_height { get; set; }

        public bool aligned { get; set; }

        public int pose { get; set; }
        public int angle { get; set; }

        public double scale { get; set; }
        public double confidence { get; set; }

        public int xError { get; set; }
        public string xMsg { get; set; }


    }

    public class SearchResult
    {
        public double value { get; set; }
        public string path { get; set; }
    }
    public class VerificationResult
    {
        public double value { get; set; }
        public bool result { get; set; }
        public double threshold { get; set; }
    }

    public class IdentificationResult
    {


        // Properties
        public string path { get; set; }
        public string personName { get; set; }
        public double value { get; set; }
    }


    public class Person
    {


        public string Id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string description { get; set; }
        public Person()
        {
            // TODO: Complete member initialization
        }
    }

    public class Group
    {
        public string Id { get; set; }

        public string user_id { get; set; }
        public string name { get; set; }
        public List<string> personList { get; set; }

        public string description { get; set; }
    }

    public class FaceSet
    {
        public string Id { get; set; }

        public string user_id { get; set; }
        public string faceSetName { get; set; }
        public string tag { get; set; }
        public List<string> faces { get; set; }
    }


    public class UserCreatedMessage
    {

        public string Message { get; set; }
        public string UserId { get; set; }
        public bool Status { get; set; }

    }

    public class User
    {
        public string Id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string key { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<string> personList { get; set; }

        public User()
        {

            personList = new List<string>();
        }


    }
}
