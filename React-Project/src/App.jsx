import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './CSS/App.css'
import { Route, Routes } from 'react-router-dom'
import HomePage from './FCComps/HomePage'
import TeacherPage from './FCComps/TeacherPage'
import StudentPage from './FCComps/StudentPage'
import TeacherSignUp from './FCComps/TeacherSignUp'
import StudentSignUp from './FCComps/StudentSignUp'
import UpdateT from './FCComps/UpdateT'
import EditPh from './FCComps/EditPh'
import Navbar from './FCComps/Navbar';
import AdminPanel from './FCComps/AdminPanel';


function App() {
  
  return (
   <div>
    <Navbar />
     <Routes>
      <Route path='/' element={<HomePage/>}></Route>
      <Route path='/teacherPage' element={<TeacherPage/>}></Route>
      <Route path='/studentpage' element={<StudentPage/>}></Route>
      <Route path='/teacherSignUp' element={<TeacherSignUp/>}></Route>
      <Route path='/studentSignUp' element={<StudentSignUp/>}></Route>
      <Route path='/updateT' element={<UpdateT/>}></Route>
      <Route path='/editP' element={<EditPh/>}></Route>
      <Route path='/adminPanel' element={<AdminPanel/>}></Route>

    </Routes>
   </div>
  )
}

export default App
