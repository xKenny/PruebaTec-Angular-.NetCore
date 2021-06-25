import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { LibroServService } from 'src/app/services/libro-serv.service';

@Component({
  selector: 'app-libreria',
  templateUrl: './libreria.component.html',
  styleUrls: ['./libreria.component.css']
})
export class LibreriaComponent implements OnInit {
  listLibros: any[] = [];

  form: FormGroup;

  constructor(private fb: FormBuilder,
    private toastr: ToastrService,
    private _libroService: LibroServService) { 
    this.form = this.fb.group({
      titulo: ['', Validators.required],
      anio: ['', Validators.required],
      genero: ['', Validators.required],
      paginas: [''],
      editorial: ['', Validators.required],
      autor: ['', Validators.required]
    })
  }

  ngOnInit(): void {
    this.obtenerLibros();
  }

  obtenerLibros(){
    this._libroService.getListLibros().subscribe(data => {
      console.log(data);
      this.listLibros = data;
    }, error => {
      console.log(error);
    })
  }

  registrarLibro(){

    const libro: any = {
      titulo: this.form.get('titulo')?.value,
      anio: this.form.get('anio')?.value,
      genero: this.form.get('genero')?.value,
      paginas: this.form.get('paginas')?.value,
      editorial: this.form.get('editorial')?.value,
      autor: this.form.get('autor')?.value,
    }
    this._libroService.saveLibro(libro).subscribe(data => {
      this.toastr.success('El libro fue registrado con exito!', 'Libro Registrado!');
      this.obtenerLibros();
      this.form.reset();
    }, error => {
      this.toastr.error('El libro no pudo ser registrado', 'Error!');
      console.log(error);
    })
    
  }
  
  eliminarLibro(id: number){
      this._libroService.deleteLibro(id).subscribe(data => {
        this.toastr.error('El libro fue eliminado con exito', 'Libro eliminado!');
        this.obtenerLibros();
      }, error => {
        this.toastr.error('El libro no pudo ser eliminado', 'Error!');
        console.log(error);
      })
  }
}
