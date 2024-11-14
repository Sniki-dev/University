; 2. Dla tekstu wprowadzonego z klawiatury, wypisać tekst na ekran tyle razy, ile wynosi liczba wprowadzonych znaków.

section .txt
	org 100H

start:
    mov ah, 0ah                 ; DOS function that reads a line of input from the user.
    mov dx, input               ; Loads the address of input into DX
    int 21h
    

    mov cl, [input + 1]         ; Load the length of the input into CL as the loop counter

    mov ah,9
	mov dx, doubleNewLine
	int 21h

start_loop:

    cmp cl, 0                   ; Check if CL (counter) is zero
    je end                      ; If CL is zero, jump to end

    mov ah, 9                   ; DOS function to display string
    mov dx, input + 2           ; DX points to the input string, we add 2 because the first byte is maximum input length and the second byte is count of characters entered
    int 21h

    mov ah,9
	mov dx, newline
	int 21h

    dec cl                      ; Decrement the loop counter
    jmp start_loop

end:
    mov ax, 4C00h
    int 21h

section .data
    doubleNewLine db 10,13,10,13,36
    newline db 10,13,36         ; Define the newline in memory
	input db 20                 ; Input buffer size
          db 0                  ; Number of characters entered
          times 20 db "$"       ; Input characters buffer
