import React, { useState } from "react";
import "/src/CSS/teacherPage.css";
import { useNavigate } from "react-router-dom";
export default function UpdateT() {
    const nav = useNavigate();
    const [img, setSelectedImage] = useState(null);
    const [name, setName] = useState("");
    const [phone, setPhone] = useState(0);

    const [password, setPassword] = useState("");
    const [fields, setFields] = useState("");
    const [err, setErr] = useState("");
    const api = "https://proj.ruppin.ac.il/cgroup18/test2/tar1/";
    const SignUpFunction = () => {
      let regex = /^[a-zA-Z]+$/;
      if (!regex.test(name)) {
        setErr("Wrong Name Input!");
        return;
      } else {
        setErr("");
      }
      if (phone == 0) {
        setErr("Wrong Phone Number!");
        return;
      } else {
        setErr("");
      }

      if (password.length < 8) {
        setErr("Wrong Pass Input!");
        return;
      } else {
        setErr("");
      }
  
      if (fields == "") {
        setErr("Wrong Fields Input!");
        return;
      } else {
        setErr("");
      }
      if (img == null) {
        setErr("Wrong Img Input!");
        return;
      } else {
        setErr("");
      }
  
      const teacher = {
        id: 1,
        phone,
        name,
        email:JSON.parse(localStorage.getItem('email')),
        password,
        fields,
        img,
      };
    insertTeahcer(teacher);
    }
    const insertTeahcer = (teacher) => {
      fetch(api + "api/Teacher/UpdateT", {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(teacher),
      })
        .then((response) => {
          if (!response.ok) {
            throw new Error("Network response was not ok");
          }
          return response.json();
        })
        .then((data) => {
          console.log("Teacher inserted");
         
          nav("/teacherPage");
        })
        .catch((error) => {
          console.error("Error:", error);
        });
    };
    return (
      <div className="wrapper" >
        <h2>Teacher Update</h2>
        <h2 style={{ color: "red" }}>{err}</h2>
        <form action="#">
          <div className="input-box">
            <input
              type="number"
              placeholder="Enter your Phone"
              onChange={(e) => {
                setPhone(e.target.value);
              }}
            ></input>
          </div>
          <div className="input-box">
            <input
              type="text"
              placeholder="Enter your name"
              onChange={(e) => {
                setName(e.target.value);
              }}
            ></input>
          </div>
        
          <div className="input-box">
            <input
              type="password"
              placeholder="Create password"
              onChange={(e) => {
                setPassword(e.target.value);
              }}
            ></input>
          </div>
          <div className="input-box">
            <input
              type="text"
              placeholder="Enter Field of Study"
              onChange={(e) => {
                setFields(e.target.value);
              }}
            ></input>
          </div>
  
          <div className="mb-1">
            Image <span className="font-css top">*</span>
            <div className="">
              <input
                type="file"
                id="file-input"
                name="ImageStyle"
                onChange={(event) => {
                  let file = event.target.files[0];
                  const reader = new FileReader();
  
                  reader.onload = function(event) {
                      const base64String = event.target.result;
                      console.log(base64String);
                      // Display the Base64 string in a textarea
                      setSelectedImage(base64String.split(",")[1]);
                  };
          
                  reader.onerror = function(error) {
                      console.error('Error: ', error);
                  };
          
                  // This will start the file reading process
                  reader.readAsDataURL(file);
                }}
              />
            </div>
          </div>
          <div className="input-box button">
            <input
              type="button"
              value="Register Now"
              onClick={SignUpFunction}
            ></input>
          </div>
          <div className="text">
            <h3>
              Want to go Back?{" "}
              <a
                onClick={() => {
                  nav("/teacherPage");
                }}
              >
                Go Back
              </a>
            </h3>
          </div>
        </form>
      </div>
    );
}
