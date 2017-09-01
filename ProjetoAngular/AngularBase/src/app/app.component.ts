import { Component, OnInit } from '@angular/core';
import { PessoaService } from "./services/pessoa.service";
import { Pessoa } from "./models/pessoa";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [PessoaService]
})

export class AppComponent implements OnInit{
  
  title = 'Documentações';
  pessoas: Pessoa[] = [];

  constructor(private pessoaService: PessoaService) {

  }

  ngOnInit(): void {
    this.pessoaService.buscarTodasCore().subscribe(
      data => {
        this.pessoas = data;
        console.log(this.pessoas);
      },
      error =>{
        console.log("Um erro ocorreu.");
      },
      () => {
        console.log("Requisição completada com sucesso.");
      }
    );

  }
}