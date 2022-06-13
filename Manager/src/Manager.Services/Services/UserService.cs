using AutoMapper;
using Azure.Storage.Blobs;
using EscNet.Hashers.Interfaces.Algorithms;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using QRCoder;

namespace Manager.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IArgon2IdHasher _hasher;
        public UserService(IMapper mapper, IUserRepository userRepository, IArgon2IdHasher hasher)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _hasher = hasher;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var userExistsWithEmail = await _userRepository.GetByEmail(userDTO.Email);
            var userExistsWithUsername = await _userRepository.SearchByUsername(userDTO.Username);
            if (userExistsWithEmail != null)
            {
                throw new DomainException("Já existe um usuário cadastrado com o email informado.");
            }
            if (userExistsWithUsername != null)
            {
                throw new DomainException("Já existe um usuário cadastrado com este nome de usuário informado informado.");
            }

            var user = _mapper.Map<User>(userDTO);
            user.Validate();
            var password = _hasher.Hash(user.Password);
            
            user.SetPassword(password);
            user.SetRole("user");

            var userCreated = await _userRepository.Create(user);

            if (userCreated != null)
            {
                var qrcode = await GenerateImageQRCode(_mapper.Map<UserDTO>(userCreated));
                user.SetQRCode(qrcode.ToString());
            }

            return _mapper.Map<UserDTO>(userCreated);
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var userExists = await _userRepository.Get(userDTO.Id);

            if (userExists != null)
            {
                throw new DomainException("Não existe nenhum usuário com o id informado.");
            }

            var user = _mapper.Map<User>(userDTO);
            user.Validate();
            user.SetPassword(_hasher.Hash(user.Password));

            var userUpdated = await _userRepository.Update(user);
            return _mapper.Map<UserDTO>(userUpdated);
        }

        public async Task Remove(long id)
        {
            await _userRepository.Remove(id);
        }

        public async Task<UserDTO> Get(long id)
        {
            var user = await _userRepository.Get(id);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> Get()
        {
            var allUsers = await _userRepository.Get();

            return _mapper.Map<List<UserDTO>>(allUsers);
        }

        public async Task<List<UserDTO>> SearchByName(string name)
        {
            var allUser = await _userRepository.SearchByEmail(name);

            return _mapper.Map<List<UserDTO>>(allUser);
        }

        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
            var allUser = await _userRepository.SearchByEmail(email);

            return _mapper.Map<List<UserDTO>>(allUser);
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<string> GenerateImageQRCode(UserDTO userDTO)
        {
            var userExists = await _userRepository.GetByEmail(userDTO.Email);

            if (userExists == null)
            {
                throw new DomainException("Usuário não encontrado.");
            }

            var url = "URL BD" + userExists.Id;
            var filename = userExists.Id + ".png";
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new BitmapByteQRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(20);

            var blobClient = new BlobClient("CNN STRING AZURE", "qrcode", filename);

            using (var stream = new MemoryStream(qrCodeImage))
            {
                blobClient.Upload(stream);
            }

            return blobClient.Uri.AbsoluteUri;
        }
    }
}