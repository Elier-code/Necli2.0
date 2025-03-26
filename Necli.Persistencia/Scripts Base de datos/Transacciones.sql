CREATE TABLE Transacciones (
    Numero INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATE,
    NumeroCuentaOrigen VARCHAR(15),
    NumeroCuentaDestino VARCHAR(15),
    Monto FLOAT,
    Tipo VARCHAR(50)
);

INSERT INTO Transacciones (Fecha, NumeroCuentaOrigen, NumeroCuentaDestino, Monto, Tipo) VALUES
('2025-03-25', '3001234567', '3109876543', 200.00, 'Envio'),
('2025-03-25', '3124567890', '3157891234', 150.50, 'Recibio'),
('2025-03-25', '3185678901', '3192345678', 300.75, 'Recibio'),
('2025-03-25', '3203456789', '3214567890', 100.00, 'Envio'),
('2025-03-25', '3225678901', '3236789012', 250.00, 'Recibio'),
('2025-03-25', '3001234567', '3124567890', 500.00, 'Recibio'),
('2025-03-25', '3109876543', '3157891234', 750.25, 'Envio'),
('2025-03-25', '3185678901', '3192345678', 400.50, 'Envio'),
('2025-03-25', '3203456789', '3214567890', 600.00, 'Recibio'),
('2025-03-25', '3225678901', '3236789012', 900.75, 'Envio'),
('2024-03-25', '3001234567', '3109876543', 200.00, 'Recibio');








